import { Injectable } from "@angular/core";

import { PadService } from "./pad.service";

@Injectable()
export class PageService {
  private _openedPageIndex: number | null;
  private _selectedTaskIndexOnPage: number | null;

  constructor(private padService: PadService) {}
  
  get openedPageIndex() {
    return this._openedPageIndex;
  }

  set openedPageIndex(pageIndex: number) {
    this._openedPageIndex = pageIndex;
  }

  get selectedTaskIndexOnPage() {
    return this._selectedTaskIndexOnPage;
  }

  set selectedTaskIndexOnPage(taskIndexOnPage: number) {
    this._selectedTaskIndexOnPage = taskIndexOnPage;
  }

  pageCount() {
    return this.padService.getPageCount();
  }

  clearOpenedPage() {
    this._openedPageIndex = null;
  }

  clearSelectedTask() {
    this._selectedTaskIndexOnPage = null;
  }
}
