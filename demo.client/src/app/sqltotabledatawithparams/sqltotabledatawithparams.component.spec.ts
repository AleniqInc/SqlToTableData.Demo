import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SqltotabledatawithparamsComponent } from './sqltotabledatawithparams.component';

describe('SqltotabledatawithparamsComponent', () => {
  let component: SqltotabledatawithparamsComponent;
  let fixture: ComponentFixture<SqltotabledatawithparamsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SqltotabledatawithparamsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SqltotabledatawithparamsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
