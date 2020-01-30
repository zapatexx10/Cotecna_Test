namespace Cotecna.Inspections.Infrastructure.Static
{
    public static class Queries
    {

        #region .:: Inspections ::.
        public const string GetInspectionsByInspectorId = @"SELECT i.Id, i.InspectionDate, i.Customer,i.Observations,i.Status, i.InspectorId,
                                                            ins.Id,ins.InspectorName FROM Inspection i INNER JOIN Inspector ins on i.InspectorID= ins.Id
                                                            WHERE InspectorId= @InspectorId";

        public const string GetAllInspections = @"SELECT i.Id, i.InspectionDate, i.Customer,i.Observations,i.Status, i.InspectorId,
                                                  ins.Id,ins.InspectorName FROM Inspection i INNER JOIN Inspector ins on i.InspectorID= ins.Id";

        public const string DeleteInspection = @"DELETE FROM Inspection where Id = @InspectionId";

        public const string UpdateInspectionById = @"UPDATE Inspection SET InspectionDate = @InspectionDate, Customer = @Customer,
                                                     Observations = @Observations, Status = @Status,InspectorId= @InspectorId
                                                     WHERE Id= @InspectionId";

        public const string InsertInspection = @"INSERT INTO Inspection(InspectionDate, Customer,Observations,Status,InspectorId)
                                                 VALUES (@InspectionDate, @Customer,@Observations,@Status,@InspectorId);";
        #endregion

        #region .:: Inspectors ::.
        public const string GetInspectors = @"Select Id,InspectorName from Inspector";
        #endregion
    }
}
