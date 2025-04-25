import React from "react";
import NavBar from "../components/NavBar";

interface LayoutProps {
  children: React.ReactNode;
}

function Layout({ children }: LayoutProps) {
  return (
    <div className="d-flex flex-column flex-md-row ">
      <NavBar />
      <main className="flex-grow-1">{children}</main>
    </div>
  );
}

export default Layout;
