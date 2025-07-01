import { Product } from '../models/product.model';
import { cartItem } from '../models/cart-item.model';
import { Category } from '../models/category.enum';

export class EcommerceService {
    private products: Product[] = [];
    private cart: cartItem[] = [];

    constructor() {
        this.products = [
            { id: 1, name: "Laptop", category: Category.Electronics, price: 45000, stock: 3 },
            { id: 2, name: "Jeans", category: Category.Clothing, price: 1500, stock: 10 },
            { id: 3, name: "Rice Bag", category: Category.Grocery, price: 700, stock: 5 }
        ];
    }

    viewProducts(): void {
        console.log("Available Products:");
        for (const p of this.products) {
            console.log(`${p.name} | ₹${p.price} | In Stock: ${p.stock} | Category: ${p.category}`);
        }
    }

    addToCart(productId: number, quantity: number): void {
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
        } else {
            this.cart.push({ product, quantity });
        }

        product.stock -= quantity;
        console.log(`${quantity} x ${product.name} added to cart.`);
    }

    removeFromCart(productId: number): void {
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

    viewCart(): void {
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

    private getDiscount(total: number): number {
        if (total >= 10000) return 0.15;
        if (total >= 5000) return 0.10;
        return 0;
    }

    viewUpdatedInventory(): void {
        this.viewProducts();
    }
}
