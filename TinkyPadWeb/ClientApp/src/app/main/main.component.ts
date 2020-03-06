import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { PadService } from '../shared/pad.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  constructor(private padService: PadService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    let activePageIndex = this.padService.getActivePageIndex();
    this.router.navigate([activePageIndex], {relativeTo: this.route});
  }

}
