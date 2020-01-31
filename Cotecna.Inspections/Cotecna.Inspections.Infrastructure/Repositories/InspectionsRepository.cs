using Cotecna.Inspections.Abstractions.Entities;
using Cotecna.Inspections.Abstractions.Repositories;
using Cotecna.Inspections.Infrastructure.Configuration;
using Cotecna.Inspections.Infrastructure.Static;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Cotecna.Inspections.Infrastructure.Repositories
{
    public class InspectionsRepository : IInspectionsRepository
    {
        #region .:: Variables ::.
        private readonly DatabaseConfiguration _configuration;
        #endregion

        #region .:: Constructor ::.

        public InspectionsRepository(DatabaseConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion

        public bool AddInspection(Inspection inspectionToAdd)
        {
            using (IDbConnection db = new SqlConnection(_configuration.ConnectionString))
            {
                try
                {
                    db.Open();

                    DynamicParameters inspectionParams = new DynamicParameters();
                    inspectionParams.Add("@InspectionDate", inspectionToAdd.InspectionDate);
                    inspectionParams.Add("@Customer", inspectionToAdd.Customer);
                    inspectionParams.Add("@Observations", inspectionToAdd.Observations);
                    inspectionParams.Add("@Status", inspectionToAdd.Status);
                    inspectionParams.Add("@InspectorId", inspectionToAdd.Inspector.Id);

                    var result = db.Execute(Queries.InsertInspection, inspectionParams, commandType: CommandType.Text);
                    db.Close();

                    return (result == 0) ? false : true;
                }
                catch (Exception ex)
                {
                    db.Close();
                    throw;
                }

            }
        }

        public bool DeleteInspectionById(int inspectionId)
        {
            using (IDbConnection db = new SqlConnection(_configuration.ConnectionString))
            {
                try
                {
                    db.Open();
                    DynamicParameters inspectionParams = new DynamicParameters();
                    inspectionParams.Add("@InspectionId", inspectionId);

                    var result = db.Execute(Queries.DeleteInspection, inspectionParams, commandType: CommandType.Text);
                    db.Close();

                    return (result == 0) ? false : true;
                }
                catch (Exception ex)
                {
                    db.Close();
                    throw;
                }
            }
        }

        public List<Inspection> GetAllInspections()
        {
            using (IDbConnection db = new SqlConnection(_configuration.ConnectionString))
            {
                try
                {
                    db.Open();
                    var result = db.Query<Inspection, Inspector, Inspection>(Queries.GetAllInspections, (inspection, inspector) =>
                    {
                        inspection.Inspector = inspector;
                        return inspection;
                    });

                    return result.ToList();
                }
                catch (Exception ex)
                {
                    db.Close();    
                    throw;
                }
            } 
        }


        public List<Inspection> GetInspectionsByInspectorId(int inspectorId)
        {
            using (IDbConnection db = new SqlConnection(_configuration.ConnectionString))
            {
                try
                {
                    db.Open();

                    var inspections = db.Query<Inspection>(Queries.GetInspectionsByInspectorId, new { Id = inspectorId }).ToList();
                    
                    db.Close();

                    return inspections;
                }
                catch (Exception ex)
                {
                    db.Close();
                    throw;
                }
            }
        }

        public List<Inspector> GetInspectors()
        {
            using (IDbConnection db = new SqlConnection(_configuration.ConnectionString))
            {
                try
                {
                    db.Open();
                    var result = db.Query<Inspector>(Queries.GetInspectors).ToList();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
                
        }

        public bool UpdateInspection(Inspection inspectionToUpdate)
        {
            using (IDbConnection db = new SqlConnection(_configuration.ConnectionString))
            {
                try
                {
                    db.Open();

                    DynamicParameters inspectionParams = new DynamicParameters();
                    inspectionParams.Add("@InspectionDate", inspectionToUpdate.InspectionDate);
                    inspectionParams.Add("@Customer", inspectionToUpdate.Customer);
                    inspectionParams.Add("@Observations", inspectionToUpdate.Observations);
                    inspectionParams.Add("@Status", inspectionToUpdate.Status);
                    inspectionParams.Add("@InspectorId", inspectionToUpdate.Inspector.Id);
                    inspectionParams.Add("@InspectionId", inspectionToUpdate.Id);

                    var result = db.Execute(Queries.UpdateInspectionById, inspectionParams, commandType: CommandType.Text);
                    db.Close();

                    return (result == 0) ? false : true;
                }
                catch (Exception ex)
                {
                    db.Close();
                    throw;
                }

            }
        }
    }
}
