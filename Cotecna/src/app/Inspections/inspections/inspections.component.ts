import { InspectionsService } from './../../services/inspections.service';
import { Component, OnInit } from '@angular/core';
import { Inspection, Inspector } from 'src/app/models/inspection';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog, MatDialogConfig, MatSnackBar } from '@angular/material';
import { InspectionsDialogComponent } from 'src/app/inspections-dialog/inspections-dialog.component';

@Component({
  selector: 'app-inspections',
  templateUrl: './inspections.component.html',
  styleUrls: ['./inspections.component.css']
})
export class InspectionsComponent implements OnInit {
  ELEMENT_DATA: Inspection[] = [];
  inspectorsData: Inspector[] = [];
  searchValue = '';
  displayedColumns: string[] = ['id', 'customer', 'observations', 'status', 'inspectorName', 'delete', 'update'];
  dataSource: MatTableDataSource<Inspection>;
  constructor(private inspectionservice: InspectionsService,
              private dialog: MatDialog, private _snackBar: MatSnackBar) { }

  ngOnInit() {
    this.getAllInspections();
    this.getInspectors();
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  public redirectToUpdate = (id: string) => {

  }

  public getAllInspections() {
      this.inspectionservice.GetInspections().subscribe((inspectionList) => {
      this.ELEMENT_DATA = inspectionList;
      this.dataSource = new MatTableDataSource(this.ELEMENT_DATA);
      });
   }

  public redirectToDelete = (id: string) => {
    const ans = confirm('Do you want to delete blog post with id: ' + id) + ' ? ';
    if (ans) {
          this.inspectionservice.DeleteInspection(id).subscribe((data) => {
          this.getAllInspections();
          });
        }
  }

  public getInspectors() {
      this.inspectionservice.GetInspectors().subscribe((inspectorsList) => {
      this.inspectorsData = inspectorsList;
      });
  }

  public  getInspectionsByInspectorId(event: any): void {
    console.log('eventvalue', event.value);
    this.inspectionservice.GetInspectionsById(event.value).subscribe((inspectionList) => {
    this.ELEMENT_DATA = inspectionList;
    this.dataSource = new MatTableDataSource(this.ELEMENT_DATA);
    });
  }

  public clearFilters() {
    this.dataSource.filter = '';
    this.searchValue = null;
    this.getAllInspections();
    this.getInspectors();
  }

  public onCreate() {
    this.dialog.open(InspectionsDialogComponent);
  }

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
       duration: 2000,
    });
  }
}
