import { NavList } from "@primer/react";
import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

export interface ICustomNavLinkProps {
    to: string;
    text: string,
    icon: React.ReactElement,
}

export default function CustomNavLink(props: ICustomNavLinkProps) {
    const [isActive, setActive] = useState(false);
    const navigate = useNavigate();

    function linkClick(e: any) {
        e.preventDefault();
        navigate(props.to);
    }

    useEffect(() => {
        setActive(window.location.pathname == props.to);
    }, [navigate]);

    return (
        <NavList.Item as="a" onClick={linkClick} aria-current={isActive ?? "page"}>
            <NavList.LeadingVisual>
                {props.icon}
            </NavList.LeadingVisual>
            {props.text}
        </NavList.Item>
    );
}