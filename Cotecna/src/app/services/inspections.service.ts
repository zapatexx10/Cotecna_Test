import { Inspection, Inspector } from './../models/inspection';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, retry, catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class InspectionsService {

  constructor(private http: HttpClient) { }

  public GetInspections(): Observable<Inspection[]> {
    return this.http.get('https://localhost:44345/api/Inspection').
      pipe(
        map((inspections: Inspection[]) => {
          return inspections.map(inspection => {
            return new Inspection(inspection);
          }); })
      );
  }

  public GetInspectors(): Observable<Inspector[]> {
    return this.http.get('https://localhost:44345/api/Inspection/api/inspectors').
      pipe(
        map((inspections: Inspector[]) => {
          return inspections.map(inspector => {
            return new Inspector(inspector);
          }); })
      );
  }

  public DeleteInspection(id: string): Observable<Inspection> {
    return this.http.delete<Inspection>('https://localhost:44345/api/Inspection/' + id)
    .pipe(
      retry(1)
    );
   }

   public GetInspectionsById(id: string): Observable<Inspection[]> {
    console.log('id', id);
    return this.http.get('https://localhost:44345/api/Inspection/' + id)
      .pipe(
        map((inspections: Inspection[]) => {console.log('inspections123', inspections);
          return inspections.map(inspection => {
            return new Inspection(inspection);
          }); })
      );
  }
}

