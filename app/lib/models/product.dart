class Product {
  String description;
  String id;
  String insertDate;

  Product({this.description, this.id, this.insertDate});

  Product.fromJson(Map<String, dynamic> json) {
    description = json['description'];
    id = json['id'];
    insertDate = json['insertDate'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['description'] = this.description;
    data['id'] = this.id;
    data['insertDate'] = this.insertDate;
    return data;
  }
}