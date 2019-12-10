import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { Router } from '@angular/router';
import { TestBed, async } from '@angular/core/testing';
import { TelaAbas } from './tela-abas';

describe('TelaAbas', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [TelaAbas],
      schemas: [CUSTOM_ELEMENTS_SCHEMA]
    }).compileComponents();
  }));

  it('should create the tabs page', () => {
    const fixture = TestBed.createComponent(TelaAbas);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });
});