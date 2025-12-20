using MachineWeb.BAL;
using MachineWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.Json.Serialization;

namespace MachineWeb.Controllers.adminpanel
{
    public class CreateProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly DropDownService _dropDownService;
        private readonly FileUploadService _fileuploadservice;
        public CreateProductController(ProductService aproductService, FileUploadService afileuploadservice, DropDownService adropDownService)
        {
            this._productService = aproductService;
            this._fileuploadservice = afileuploadservice;
            this._dropDownService = adropDownService;
        }
        public async Task<IActionResult> Index(string Id)
        {
            CommonRequestDto<DropDownReq> requestDto_catgeoryddl = new CommonRequestDto<DropDownReq>
            {
                CompanyId = 1,
                UserId = 1,
                Data= new DropDownReq
                {
                    SearchDDL="Category",
                    ProcId=1
                }
            };
            var Categoryresponse = await _dropDownService.BindDropDown(requestDto_catgeoryddl);

            ViewBag.Category = Categoryresponse.Data;


            if (string.IsNullOrEmpty(Id))
            {
                return View(new ProductResponseDto());
            }


            CommonRequestDto<ProductRequestDto> requestDto = new CommonRequestDto<ProductRequestDto>
            {
                CompanyId = 1,
                UserId = 1,
                Data = new ProductRequestDto
                {
                    ProductGuid = Id
                }
            };
            var res = await _productService.GetProductService(requestDto);
            if (res != null)
            {
                if(res.Data.ProductImagesJson != null)
                {
                    res.Data.productImageDtos = System.Text.Json.JsonSerializer.Deserialize<List<ProductImageDto>>(res.Data.ProductImagesJson);

                    res.Data.productImageDtos.ForEach(x => x.Image = "webimages/" + x.Image);
                }
                return View(res.Data);
            }
            return View(null);
        }
       
        public async Task<JsonResult> SaveProduct([FromForm] ProductRequestDto productRequestDto)
        {
            string _imagename = string.Empty;
            List<string> _imagelist = new List<string>();
             
            if (productRequestDto.images != null)
            {
                _imagelist = await _fileuploadservice.SaveImageInFolder(productRequestDto.images);
            }


            DataTable imageTable = _fileuploadservice.ConvertImageListToDataTable(_imagelist);
            var res= new CommonResponseDto<_productresdto>();
            if (productRequestDto.ProductGuid != null)
            {
                CommonRequestDto<ProductRequestDto> requestDto = new CommonRequestDto<ProductRequestDto>
                {
                    CompanyId = 1,
                    UserId = 1,
                    Data = new ProductRequestDto
                    {
                        ProductGuid = productRequestDto.ProductGuid,
                        CategoryId = productRequestDto.CategoryId,
                        ProductName = productRequestDto.ProductName,
                        Description = productRequestDto.Description,
                        Image = _imagename,
                        IsActive = productRequestDto.IsActive,
                        IsShowOnWeb = productRequestDto.IsShowOnWeb
                    }
                };
                res = await _productService.UpdateProduct(requestDto, imageTable);
            }
            else
            {
                CommonRequestDto<ProductRequestDto> requestDto = new CommonRequestDto<ProductRequestDto>
                {
                    CompanyId = 1,
                    UserId = 1,
                    Data = new ProductRequestDto
                    {
                        CategoryId = productRequestDto.CategoryId,
                        ProductName = productRequestDto.ProductName,
                        Description = productRequestDto.Description,
                        Image = _imagename,
                        IsActive = productRequestDto.IsActive,
                        IsShowOnWeb = productRequestDto.IsShowOnWeb
                    }
                };
                 res = await _productService.SaveProduct(requestDto, imageTable);
            }


               
            if (res != null)
            {
                if (res.Flag == 1)
                {
                    return Json(new { success = true, message = res.Message });
                }
                else
                {
                    return Json(new { success = false, message = res.Message });
                }
            }
            else
            {
                return Json(new { success = false, message = "Invalid data" });
            }

            return Json(new { success = false, message = "Something went wrong" });
        }

        public async Task<JsonResult> DeleteImage(string productImageGuid)
        {
            CommonRequestDto<string> requestDto = new CommonRequestDto<string>
            {
                CompanyId = 1,
                UserId = 1,
                Data = productImageGuid
            };

            var res = await _productService.DeleteProductImage(requestDto);
            if (res != null)
            {
                if (res.Flag == 1)
                {
                    return Json(new { success = true, message = res.Message });
                }
                else
                {
                    return Json(new { success = false, message = res.Message });
                }
            }
            else
            {
                return Json(new { success = false, message = "Invalid data" });
            }

            return Json(new { success = false, message = "Something went wrong" });
        }
    }


}
