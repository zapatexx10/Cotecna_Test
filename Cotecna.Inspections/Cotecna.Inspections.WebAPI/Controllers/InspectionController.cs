using Cotecna.Inspections.Abstractions.Entities;
using Cotecna.Inspections.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection;

namespace Cotecna.Inspections.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionController : ControllerBase
    {
        #region .:: Variables ::.
        private readonly IInspectionService _inspectionService;
        #endregion

        #region .:: Constructor ::.
        public InspectionController(IInspectionService inspectionService)
        {
            _inspectionService = inspectionService;
        }
        #endregion

        #region .:: Public Methods ::.

        // GET: api/Inspection
        [HttpGet (Name="GetAllInspections")]
        public ActionResult GetAllInspections()
        {
            var inspections = _inspectionService.GetAllInspections();
            if (inspections != null)
            {
                return Ok(inspections);
            }

            return NotFound();
        }

        // GET: api/Inspectors
        [HttpGet]
        [Route("api/test")]
        public ActionResult GetInspectors()
        {
            var inspectors = _inspectionService.GetInspectors();
            if (inspectors != null)
            {
                return Ok(inspectors);
            }

            return NotFound();
        }

        // GET: api/Inspection/5
        [HttpGet("{id}", Name = "GetInspectionsByInspectorId")]
        public ActionResult GetInspectionsByInspectorId(int id)
        {
            var inspections = _inspectionService.GetInspectionsByInspectorId(id);
            if (inspections != null)
            {
                return Ok(inspections);
            }
            return NotFound();
        }

        // POST: api/Inspection
        [HttpPost]
        public ActionResult CreateInspection([FromBody] Inspection inspection)
        {
            if (IsAnyNullOrEmpty(inspection))
            {
                return BadRequest();
            }

            var result = _inspectionService.AddInspection(inspection);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        // PUT: api/Inspection/5
        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] int id, [FromBody] Inspection inspection)
        {
            if (IsAnyNullOrEmpty(inspection))
            {
                return BadRequest();
            }

            var result = _inspectionService.UpdateInspectionById(id,inspection);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _inspectionService.DeleteInspectionById(id);
            if (result)
            {
                return Ok();
            }

            return NotFound();
        }

        #endregion

        #region .:: Private Methods ::.

        bool IsAnyNullOrEmpty(object myObject)
        {
            foreach (PropertyInfo pi in myObject.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(string))
                {
                    string value = (string)pi.GetValue(myObject);
                    if (string.IsNullOrEmpty(value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion
    }
}
