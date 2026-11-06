import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Setup } from '../models/setup.models'; // <-- L'import crucial de ton nouveau fichier

@Injectable({
  providedIn: 'root'
})
export class SetupService {
  private http = inject(HttpClient);
  
  private apiUrl = 'http://localhost:5000/api/setups'; 

  // Fini le 'any', on exige un tableau de 'Setup'
  getSetups(): Observable<Setup[]> {
    return this.http.get<Setup[]>(this.apiUrl);
  }

  getSetupById(id: string): Observable<Setup> {
    return this.http.get<Setup>(`${this.apiUrl}/${id}`);
  }

  // Pour la création, on utilise Partial<Setup> car on n'envoie pas l'Id (généré par la base)
  createSetup(setupPayload: Partial<Setup>): Observable<Setup> {
    return this.http.post<Setup>(this.apiUrl, setupPayload);
  }
  
  updateSetup(id: string, setup: Setup): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, setup);
  }
}