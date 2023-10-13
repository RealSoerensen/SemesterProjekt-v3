import React from 'react';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Nav from './components/nav/Nav';
import Footer from './components/footer/Footer';

function App() {
  return (
    <BrowserRouter>
    <Nav />
      <Routes>
        <Route path="/" element={<div>Home</div>} />
        <Route path="/about" element={<div>About</div>} />
      </Routes>
      <Footer />
    </BrowserRouter>
  );
}

export default App;
