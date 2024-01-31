// lordicon.service.ts

import { Injectable, AfterViewInit } from '@angular/core';
import lottie from 'lottie-web';
import { defineElement } from '@lordicon/element';

@Injectable({
  providedIn: 'root',
})
export class LordiconService implements AfterViewInit {
  ngAfterViewInit() {
    // Define "lord-icon" custom element with default properties
    defineElement(lottie.loadAnimation);
  }
}
