import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionsDialogComponent } from './inspections-dialog.component';

describe('InspectionsDialogComponent', () => {
  let component: InspectionsDialogComponent;
  let fixture: ComponentFixture<InspectionsDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionsDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionsDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
