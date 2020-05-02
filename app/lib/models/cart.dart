import 'package:app/models/cardItem.dart';

class Cart {
  final String place;
  final DateTime purchaseDate;
  final List<CartItem> cartItems;

  Cart({this.place, this.purchaseDate, this.cartItems});

  @override
  String toString() {
    return 'Cart{place: $place, purchaseDate: $purchaseDate}';
  }

}