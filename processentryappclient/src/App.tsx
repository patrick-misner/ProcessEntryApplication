// import { useAuth0 } from "@auth0/auth0-react"
import React from 'react';
import { Route, Routes } from "react-router-dom";
import './App.css';
import DashboardPage from "./pages/dashboard-page";
import ProcessentryPage from './pages/processentry-page';
import ErrorPage from './pages/error';
// import { fileURLToPath } from "url";

function App() {
  return (

    



    <Routes>
      <Route path="/" element={<DashboardPage />} />
      <Route path="/processentry/new" element={<ProcessentryPage />} />
      <Route path="/processentry" element={<ProcessentryPage />} />
      <Route path="*" element={<ErrorPage />} />

    </Routes>
  );
}

export default App;
