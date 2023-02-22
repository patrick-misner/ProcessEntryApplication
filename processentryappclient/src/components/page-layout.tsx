import React, { PropsWithChildren } from 'react';
import NavBar from './navigation/nav-bar';

const PageLayout = ({ children }: PropsWithChildren) => (
  <div className="page-layout dark:bg-slate-900">
    <NavBar />
    <div className="page-layout__content">{children}</div>
  </div>
);
export default PageLayout;
