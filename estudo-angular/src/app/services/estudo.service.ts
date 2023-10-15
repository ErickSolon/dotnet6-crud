import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import Multados from '../models/multados.model';

@Injectable({
  providedIn: 'root'
})
export class EstudoService {
  constructor(private http: HttpClient) { }

  baseURL: string = "https://localhost:7042/api/Detran"

  getAll() : Observable<Multados[]> {
    return this.http.get<Multados[]>(this.baseURL);
  }

  getById(id?: Number) : Observable<Multados> {
    return this.http.get<Multados>(`${this.baseURL}/${id}`);
  }

  save(multados: Multados) : Observable<Multados> {
    return this.http.post<Multados>(this.baseURL, multados);
  }

  updateById(id?: Number, multados?: Multados) : Observable<Multados> {
    return this.http.put<Multados>(`${this.baseURL}/${id}`, multados);
  }

  deleteById(id?: Number) : Observable<Multados>{
    return this.http.delete<Multados>(`${this.baseURL}/${id}`);
  }
}
