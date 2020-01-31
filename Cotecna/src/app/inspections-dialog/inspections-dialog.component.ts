import { Component, OnInit } from '@angular/core';
import { InspectionsService } from '../services/inspections.service';
import { Inspector } from '../models/inspection';
import { FormGroup, FormControl } from '@angular/forms';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-inspections-dialog',
  templateUrl: './inspections-dialog.component.html',
  styleUrls: ['./inspections-dialog.component.css']
})
export class InspectionsDialogComponent implements OnInit {
  inspectorsData: Inspector[] = [];
  durationInSeconds = 5;
  constructor(private inspectionservice: InspectionsService,
              private _snackBar: MatSnackBar) { }

  ngOnInit() {
    this.getInspectors();
  }

  public getInspectors() {
    this.inspectionservice.GetInspectors().subscribe((inspectorsList) => {
    this.inspectorsData = inspectorsList;
    });
  }

    // openSnackBar(action: string) {
    //   this._snackBar.open('Not Implemented yet', action, {
    //     duration: 2000,
    //   });
    // }
    openSnackBar(message: string, action: string) {
      this._snackBar.open(message, action, {
         duration: 2000,
      });
    }

    // export class ProfileEditorComponent {
    //   profileForm = new FormGroup({
    //     inspection: new FormGroup({
    //       customer: new FormControl(''),
    //       observation: new FormControl(''),
    //       state: new FormControl(''),
    //       zip: new FormControl('')
    //     })
    //   });
  }
