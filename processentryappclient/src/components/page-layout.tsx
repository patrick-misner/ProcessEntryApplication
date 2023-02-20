import React from "react";
import NavBar from "./navigation/nav-bar";


interface Props {
  children: JSX.Element;
}


const PageLayout = (props: Props) => {
  return (
    <div className="page-layout dark:bg-slate-900">
      <NavBar />
      <div className="page-layout__content">{props.children}</div>
    </div>
  );
};
export default PageLayout;