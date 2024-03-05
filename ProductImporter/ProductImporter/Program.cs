using ProductImporterApp;
using ProductImporterApp.Model;
using ProductImporterApp.Shared;
using ProductImporterApp.Source;
using ProductImporterApp.Target;

var configuration = new Configuration();

var priceParser = new PriceParser();
var productSource = new ProductSource(configuration, priceParser);

var productFormatter = new ProductFormatter();
var productTarget = new ProductTarget(configuration, productFormatter);

var productImporter = new ProductImporter(productSource, productTarget);

productImporter.Run();
