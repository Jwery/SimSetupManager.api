import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; // <-- Ajout
import { SetupService } from './core/services/setup.service';
import { Setup } from './core/models/setup.models';
import { TouchSliderComponent } from './shared/components/touch-slider/touch-slider.component';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule, TouchSliderComponent], // <-- Ajout ici
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
// ... le reste du code reste identique
export class AppComponent implements OnInit {
  setupService = inject(SetupService);
  setups: Setup[] = [];

  ngOnInit() {
    this.setupService.getSetups().subscribe({
      next: (data) => this.setups = data,
      error: (err) => console.error('Erreur de connexion API', err)
    });
  }

  saveSetup(setup: Setup) {
    this.setupService.updateSetup(setup.id, setup).subscribe({
      next: () => {
        console.log('Télémétrie sauvegardée en base !', setup);
        alert('Réglages sauvegardés pour la Civic !'); // Feedback rudimentaire
      },
      error: (err) => console.error('Échec de la sauvegarde', err)
    });
  }
}