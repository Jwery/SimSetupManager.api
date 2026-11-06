import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-touch-slider',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './touch-slider.component.html',
  styleUrls: ['./touch-slider.component.scss']
})
export class TouchSliderComponent {
  @Input() label: string = 'Réglage';
  @Input() min: number = 0;
  @Input() max: number = 100;
  
  // La valeur entrante
  @Input() value: number = 0;
  
  // L'événement sortant (le nom DOIT être la propriété + "Change" pour que le [()] d'Angular fonctionne)
  @Output() valueChange = new EventEmitter<number>();

  onSliderChange(event: Event) {
    const inputElement = event.target as HTMLInputElement;
    const newValue = Number(inputElement.value);
    this.value = newValue;
    // On propulse la nouvelle valeur vers le composant parent
    this.valueChange.emit(this.value);
  }
}
