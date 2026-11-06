export interface Game {
  id: string;
  name: string;
}

export interface Track {
  id: string;
  name: string;
}

export interface Vehicle {
  id: string;
  brand: string;
  name: string;
  year?: string;
  variante?: string;
}

export interface SetupConditions {
  weather: string;
  timeOfDay: string;
  trackTemp: number;
  airTemp: number;
}

export interface Setup {
  id: string;
  gameId: string;
  trackId: string;
  vehicleId: string;
  conditions: SetupConditions;
  // On garde settings en 'any' pour l'instant car la structure 
  // varie énormément entre GT7 (pièces) et Assetto Corsa (télémétrie)
  settings: any; 
  createdAt?: string;
}