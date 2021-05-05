import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

const BASE_URL = 'https://localhost:5001/api/';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  getSemesterList() {
    return this.http.get(BASE_URL + 'Szemeszter');
  }

  setSemester(name: string) {
    return this.http.post(BASE_URL + 'Szemeszter', { megnevezes: name })
  }

  getSemesterDetails(id) {
    return this.http.get(BASE_URL + 'Szemeszter/' + id);
  }

  deleteSemester(id) {
    return this.http.delete(BASE_URL + 'Szemeszter/' + id);
  }

  editSemester(id, newName) {
    return this.http.put(BASE_URL + 'Szemeszter/' + id, { id, megnevezes: newName });
  }
}
