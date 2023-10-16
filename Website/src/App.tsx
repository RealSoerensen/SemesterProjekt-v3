import { BrowserRouter, Routes, Route } from "react-router-dom";
import { AuthProvider } from "./contexts/AuthContext";
import React from "react";
import Nav from './components/Nav';
import Footer from './components/Footer';
import HomePage from './pages/HomePage';
import LoginPage from './pages/auth/LoginPage';
import RegisterPage from './pages/auth/RegisterPage';
import ProfilePage from "./pages/profile/ProfilePage";
import ProductPage from "./pages/ProductPage";
import NotFoundPage from "./pages/NotFoundPage";
import About from "./pages/AboutPage";
import Contact from "./pages/ContactPage";
import Cart from "./pages/CartPage";
import Category from "./pages/CategoryPage";
import ForgotPassword from "./pages/auth/ForgotPasswordPage";

function App() {
  return (
    <BrowserRouter>
      <AuthProvider>
        <Nav />

        <div className="container">
          <Routes>
            {["/", "/home", "/index"].map((path, index) =>
              <Route path={path} element={<HomePage />} key={index} />
            )}
            <Route path="/home" element={<HomePage />} />
            <Route path="/category/:category" element={<Category />} />
            <Route path="/about" element={<About />} />
            <Route path="/contact" element={<Contact />} />
            <Route path="/login" element={<LoginPage />} />
            <Route path="/register" element={<RegisterPage />} />
            <Route path="/forgot-password" element={<ForgotPassword />} />
            <Route path="/cart" element={<Cart />} />
            <Route path="/profile" element={<ProfilePage />} />
            <Route path="/product/:id" element={<ProductPage />} />
            <Route path="*" element={<NotFoundPage />} />
          </Routes>
        </div>

        <Footer />
      </AuthProvider>
    </BrowserRouter>
  );
}

export default App;
