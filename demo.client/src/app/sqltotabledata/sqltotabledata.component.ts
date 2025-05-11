import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sqltotabledata',
  standalone: false,
  templateUrl: './sqltotabledata.component.html',
  styleUrl: './sqltotabledata.component.css'
})
export class SqltotabledataComponent implements OnInit {

  data: any[] = [];
  columns: string[] = [];
  titles: string[] = [];
  sortColumn: string = '';
  sortDirection: 'asc' | 'desc' = 'asc';

  queryID = '1';

  constructor(private http: HttpClient) { }

  ngOnInit(): void {

    this.http.get<any[]>('/api/Query/' + this.queryID).subscribe(response => {
      this.data = response;
      if (this.data.length > 0) {
        this.columns = Object.keys(this.data[0]);
        this.titles = this.data[0];
        // remove first item with column titles
        this.data.shift();
      }
    });
  }

  sort(column: string): void {
    if (this.sortColumn === column) {
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.sortColumn = column;
      this.sortDirection = 'asc';
    }

    this.data = [...this.data].sort((a, b) => {
      const valueA = a[column];
      const valueB = b[column];

      if (valueA < valueB) {
        return this.sortDirection === 'asc' ? -1 : 1;
      }
      if (valueA > valueB) {
        return this.sortDirection === 'asc' ? 1 : -1;
      }
      return 0;
    });
  }


}
