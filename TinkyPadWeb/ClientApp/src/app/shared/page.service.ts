import { Injectable } from "@angular/core";

import { PadService } from "./pad.service";

@Injectable()
export class PageService {
  pageIndex: number;

  constructor(private padService: PadService) {}

  setPage(pageIndex: number) {
    this.pageIndex = pageIndex;
  }

  pageCount() {
    return this.padService.getPageCount();
  }
}