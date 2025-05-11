import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

interface City {
  id: number;
  name: string;
  country: string;
  elevation: number;
}


@Component({
  selector: 'app-classic',
  standalone: false,
  templateUrl: './classic.component.html',
  styleUrl: './classic.component.css'
})
export class ClassicComponent {
  public cities: City[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getCities();
  }

  getCities() {
    this.http.get<City[]>('/api/Cities').subscribe(
      (result) => {
        this.cities = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'demo.client';
}
