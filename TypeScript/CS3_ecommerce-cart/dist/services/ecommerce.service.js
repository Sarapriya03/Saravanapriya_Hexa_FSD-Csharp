"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EcommerceService = void 0;
const category_enum_1 = require("../models/category.enum");
class EcommerceService {
    constructor() {
        this.products = [];
        this.cart = [];
        this.products = [
            { id: 1, name: "Laptop", category: category_enum_1.Category.Electronics, price: 45000, stock: 3 },
            { id: 2, name: "Jeans", category: category_enum_1.Category.Clothing, price: 1500, stock: 10 },
            { id: 3, name: "Rice Bag", category: category_enum_1.Category.Grocery, price: 700, stock: 5 }
        ];
    }
    viewProducts() {
        console.log("Available Products:");
        for (const p of this.products) {
            console.log(`${p.name} | ₹${p.price} | In Stock: ${p.stock} | Category: ${p.category}`);
        }
    }
    addToCart(productId, quantity) {
        const product = this.products.find(p => p.id === productId);
        if (!product) {
            console.log("Product not found.");
            return;
        }
        if (product.stock < quantity) {
            console.log(`Not enough stock for ${product.name}.`);
            return;
        }
        const cartItem = this.cart.find(c => c.product.id === productId);
        if (cartItem) {
            cartItem.quantity += quantity;
        }
        else {
            this.cart.push({ product, quantity });
        }
        product.stock -= quantity;
        console.log(`${quantity} x ${product.name} added to cart.`);
    }
    removeFromCart(productId) {
        const index = this.cart.findIndex(c => c.product.id === productId);
        if (index === -1) {
            console.log("Product not in cart.");
            return;
        }
        const item = this.cart[index];
        item.product.stock += item.quantity;
        console.log(`${item.quantity} x ${item.product.name} removed from cart.`);
        this.cart.splice(index, 1);
    }
    viewCart() {
        if (this.cart.length === 0) {
            console.log("Cart is empty.");
            return;
        }
        console.log("\nCart Summary:");
        let total = 0;
        for (const item of this.cart) {
            const subtotal = item.product.price * item.quantity;
            total += subtotal;
            console.log(`${item.product.name} - ₹${item.product.price} x ${item.quantity}`);
        }
        const discount = this.getDiscount(total);
        const discountedTotal = total - total * discount;
        console.log(`Total: ₹${total}`);
        console.log(`Discounted Total: ₹${discountedTotal}`);
    }
    getDiscount(total) {
        if (total >= 10000)
            return 0.15;
        if (total >= 5000)
            return 0.10;
        return 0;
    }
    viewUpdatedInventory() {
        this.viewProducts();
    }
}
exports.EcommerceService = EcommerceService;
