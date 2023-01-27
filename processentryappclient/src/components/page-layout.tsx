import React, { ReactNode } from "react";
import NavBar from "./navigation/nav-bar";

interface Props {
  children?: ReactNode
}
export const PageLayout = ({ children, ...props }: Props) => {
  return (
    <div className="page-layout">
      <NavBar />
      <div className="page-layout__content">{children}</div>
    </div>
  );
};
