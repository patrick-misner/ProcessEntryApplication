import { useAuth0 } from '@auth0/auth0-react';
import React from 'react';
import { Route, Routes } from 'react-router-dom';
import { PageLoader } from './components/page-loader';
import { AuthenticationGuard } from './components/authentication-guard';
import './App.css';
import DashboardPage from './pages/dashboard-page';
import ProcessentryPage from './pages/processentry-page';
import ProcessviewPage from './pages/processview-page';
import ErrorPage from './pages/error';
import { CallbackPage } from './pages/callback-page';
// import { fileURLToPath } from "url";

function App() {
  const { isLoading } = useAuth0();

  if (isLoading) {
    return (
      <div className="page-layout">
        <PageLoader />
      </div>
    );
  }

  return (
    <Routes>
      <Route
        path="/"
        element={<AuthenticationGuard component={DashboardPage} />}
      />
      <Route
        path="/processentry/new"
        element={<AuthenticationGuard component={ProcessentryPage} />}
      />
      <Route
        path="/processentry"
        element={<AuthenticationGuard component={ProcessentryPage} />}
      />
      <Route
        path="/processview"
        element={<AuthenticationGuard component={ProcessviewPage} />}
      />
      <Route path="/callback" element={<CallbackPage />} />
      <Route path="*" element={<ErrorPage />} />
    </Routes>
  );
}

export default App;
