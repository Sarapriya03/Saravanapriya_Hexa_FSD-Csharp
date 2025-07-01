"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const ecommerce_service_1 = require("./services/ecommerce.service");
const ecommerce = new ecommerce_service_1.EcommerceService();
ecommerce.viewProducts();
ecommerce.addToCart(1, 1); // Laptop
ecommerce.addToCart(2, 2); // Jeans
ecommerce.addToCart(3, 1); // Rice Bag
ecommerce.removeFromCart(2); // Remove Jeans
ecommerce.viewCart();
ecommerce.viewUpdatedInventory();
