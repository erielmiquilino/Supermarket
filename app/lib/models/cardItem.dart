import 'package:app/models/cart.dart';
import 'package:app/models/product.dart';

class CartItem {
  final Product product;
  final double quantity;
  final double price;
  final double totalValue;
  final Cart cart;

  CartItem({this.product, this.quantity, this.price, this.totalValue, this.cart});

}