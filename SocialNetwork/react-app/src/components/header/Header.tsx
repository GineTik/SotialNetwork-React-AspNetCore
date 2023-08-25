import { AccessibilityIcon, HomeIcon, RedoIcon, SignInIcon, PersonIcon } from '@primer/octicons-react';
import { NavList } from '@primer/react';
import { NavigateFunction, useNavigate } from 'react-router-dom';
import { IUseCustomAuth, useAuth } from '../../hooks/authentication/customAuth.hook';
import CustomNavLink from '../common/CustomNavLink';

export default function SidebarHeader() {
    const authenticationSection = getAuthenticationSection(useAuth(), useNavigate());

    return (
        <NavList>
            <NavList.Item as="a">
                <NavList.LeadingVisual>
                    <AccessibilityIcon />
                </NavList.LeadingVisual>
                Social network
            </NavList.Item>

            <NavList.Divider />

            <CustomNavLink to="/" text="Home" icon={<HomeIcon />} />

            <NavList.Group title="Authentication">
                {authenticationSection}
            </NavList.Group>
        </NavList>
    );

}

function getAuthenticationSection({ isLoggedIn, logout, user }: IUseCustomAuth, navigate: NavigateFunction) {

    function logoutClick() {
        logout();
        navigate("/login");
    }

    if (isLoggedIn == true) {
        return (
            <>
                <CustomNavLink to="/profile" text={`Profile of ${user!.username}`} icon={<PersonIcon />} />
                <NavList.Item as="span" onClick={logoutClick}>
                    <NavList.LeadingVisual>
                        {<SignInIcon />}
                    </NavList.LeadingVisual>
                    Log out
                </NavList.Item>
            </>
        );
    } else {
        return (
            <>
                <CustomNavLink to="/login" text="Login" icon={<SignInIcon />} />
                <CustomNavLink to="/registration" text="Registration" icon={<RedoIcon />} />
            </>
        );
    }
}