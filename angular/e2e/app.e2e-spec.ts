import { ProductionTemplatePage } from './app.po';

describe('Production App', function() {
  let page: ProductionTemplatePage;

  beforeEach(() => {
    page = new ProductionTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
