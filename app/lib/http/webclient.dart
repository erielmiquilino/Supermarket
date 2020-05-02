import 'dart:convert';

import 'package:app/models/product.dart';
import 'package:http/http.dart';
import 'package:http_interceptor/http_interceptor.dart';

class LoggingInterceptor implements InterceptorContract {
  @override
  Future<RequestData> interceptRequest({RequestData data}) async {
    print('Request');
    print('url: ${data.url}');
    print('headers: ${data.headers}');
    print('body: ${data.body}');
    return data;
  }

  @override
  Future<ResponseData> interceptResponse({ResponseData data}) async {
    print('Response');
    print('status code: ${data.statusCode}');
    print('headers: ${data.headers}');
    print('body: ${data.body}');
    return data;
  }
}

Future<List<Product>> findAllProducts() async {
  final Client client = HttpClientWithInterceptor.build(interceptors: [
    LoggingInterceptor(),
  ]);
  final Response response =
  await client.get('http://192.168.100.64:50319/api/Products');

  List<dynamic> objectList = jsonDecode(response.body);

  List<Product> products = List();
  for(Map<String, dynamic> json in objectList){
    products.add(Product.fromJson(json));
  }
  return products;
}
