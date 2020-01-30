using Cotecna.Inspections.Abstractions.Entities;
using Cotecna.Inspections.Abstractions.Repositories;
using Cotecna.Inspections.Abstractions.Services;
using System.Collections.Generic;
using System.Linq;

namespace Cotecna.Inspections.Core
{
    public class InspectionService : IInspectionService
    {
        #region .:: Properties ::.
        private readonly IInspectionsRepository _repository;
        #endregion

        #region .:: Constructor ::.
        public InspectionService(IInspectionsRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region .:: Public Methods ::.

        public bool AddInspection(Inspection inspectionToAdd)
        {
            return _repository.AddInspection(inspectionToAdd);
        }

        public bool DeleteInspectionById(int inspectionId)
        {
            return _repository.DeleteInspectionById(inspectionId);
        }

        public List<Inspection> GetAllInspections()
        {
            return  _repository.GetAllInspections();            
        }

        public List<Inspection> GetInspectionsByInspectorId(int inspectorId)
        {
            var inspections = _repository.GetAllInspections();

            return inspections.Where(x => x.Inspector.Id == inspectorId).ToList();
        }

        public List<Inspector> GetInspectors()
        {
            return _repository.GetInspectors();
        }

        public bool UpdateInspectionById(int inspectionId, Inspection inspectionToUpdate)
        {
            return _repository.UpdateInspection(inspectionToUpdate);
        }

        #endregion

    }
}
