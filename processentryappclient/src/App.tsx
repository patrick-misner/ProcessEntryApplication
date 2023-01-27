// import { useAuth0 } from "@auth0/auth0-react"
import React from 'react';
import { Route, Routes } from "react-router-dom";
import './App.css';
import DashboardPage from "./pages/dashboard-page";
// import { fileURLToPath } from "url";

function App() {
  return (

    



    <Routes>
      <Route path="/" element={<DashboardPage />} />

    </Routes>
  );
}

export default App;
