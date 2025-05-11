import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassicComponent } from './classic.component';

describe('ClassicComponent', () => {
  let component: ClassicComponent;
  let fixture: ComponentFixture<ClassicComponent>;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ClassicComponent],
      imports: [HttpClientTestingModule]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClassicComponent);
    component = fixture.componentInstance;
    httpMock = TestBed.inject(HttpTestingController);

    fixture.detectChanges();
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should retrieve cities from the server', () => {
    const mockCities = [
      { id: 1, name: 'Belgrade', country: 'Serbia', elevation: 100 },
      { id: 2, name: 'Budapest', country: 'Romania', elevation: 75 },
      { id: 3, name: 'Athens', country: 'Greece', elevation: 50 }

    ];

    component.ngOnInit();

    const req = httpMock.expectOne('/api/Cities');
    expect(req.request.method).toEqual('GET');
    req.flush(mockCities);

    expect(component.cities).toEqual(mockCities);
  });

});
