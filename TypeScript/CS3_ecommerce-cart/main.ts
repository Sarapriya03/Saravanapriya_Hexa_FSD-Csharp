import { EcommerceService } from "./services/ecommerce.service";

const ecommerce = new EcommerceService();

ecommerce.viewProducts();
ecommerce.addToCart(1, 1); // Laptop
ecommerce.addToCart(2, 2); // Jeans
ecommerce.addToCart(3, 1); // Rice Bag
ecommerce.removeFromCart(2); // Remove Jeans
ecommerce.viewCart();
ecommerce.viewUpdatedInventory();
