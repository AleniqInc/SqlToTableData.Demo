import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SqltotabledataComponent } from './sqltotabledata.component';

describe('SqltotabledataComponent', () => {
  let component: SqltotabledataComponent;
  let fixture: ComponentFixture<SqltotabledataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SqltotabledataComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SqltotabledataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
