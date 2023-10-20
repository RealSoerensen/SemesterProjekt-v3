import { BrowserRouter, Routes, Route } from "react-router-dom";
import { AuthProvider } from "./contexts/AuthContext";
import Nav from './components/Nav';
import Footer from './components/Footer';
import HomePage from './pages/HomePage';
import LoginPage from './pages/auth/LoginPage';
import RegisterPage from './pages/auth/RegisterPage/RegisterPage';
import ProfilePage from "./pages/profile/ProfilePage";
import ProductPage from "./pages/ProductPage";
import NotFoundPage from "./pages/NotFoundPage";
import About from "./pages/AboutPage";
import Contact from "./pages/ContactPage";
import Cart from "./pages/CartPage/CartPage";
import Category from "./pages/CategoryPage";
import ForgotPassword from "./pages/auth/ForgotPasswordPage";
import LogoutPage from "./pages/auth/LogoutPage";
import { CartProvider } from "./contexts/CartContext";

function App() {
  return (
    <BrowserRouter>
      <CartProvider>
        <AuthProvider>
          <Nav />

          <div className="container-fluid" style={{ minHeight: "100vh" }}>
            <Routes>
              {["/", "/home", "/index"].map((path, index) =>
                <Route path={path} element={<HomePage />} key={index} />
              )}
              <Route path="/logout" element={<LogoutPage />} />
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
      </CartProvider>
    </BrowserRouter>
  );
}

export default App;
