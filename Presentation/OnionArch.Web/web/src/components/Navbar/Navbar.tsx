import { Link, useNavigate } from 'react-router-dom';
//models
import { Roles } from '../../models/enumerators/Roles';
//mui components
import { Box, AppBar, Toolbar, IconButton, Typography, Button, Container, styled, Stack, Drawer, MenuItem } from '@mui/material'
//icons
import LocalLibraryIcon from '@mui/icons-material/LocalLibrary';
import MenuIcon from '@mui/icons-material/Menu';
//helpers
import AuthenticationAPI from '../../utils/APIs/AuthenticationAPI';
import { deleteCookie } from '../../utils/Cookie';
import toast from 'react-hot-toast';

type NavbarType = {
    userRole: Roles
}

const Navbar = ({ userRole }: NavbarType) => {
    const navigate = useNavigate()

    const handleLogout = async () => {
        const response = await AuthenticationAPI.RevokeRefreshToken()
        if (response.status !== 200) {
            toast.error("An error occurred while logging out")
            return;
        }

        deleteCookie("jwt")
        deleteCookie("refresh")

        toast.success("Loggin out...")

        setTimeout(() => {
            window.location.href = "/"
        }, 2000)
    }

    return (
        <Box
            position="sticky"
            top={0}
            sx={{
                flexGrow: 1,
                zIndex: 999,
                marginBottom: "64px"
            }}
        >
            <AppBar>
                <Container>
                    <Toolbar disableGutters sx={{ display: "flex", alignItems: "center" }}>
                        <Stack direction="row" spacing={1} sx={{ display: "flex", alignItems: "center", marginRight: "2rem" }}>
                            <LocalLibraryIcon />
                            <Typography
                                variant="h6"
                                noWrap
                                component="a"
                                href="/"
                                sx={{
                                    display: { xs: "none", sm: "flex" },
                                    letterSpacing: '.1rem',
                                    color: 'inherit',
                                    textDecoration: 'none',
                                }}
                            >
                                Watch&Learn
                            </Typography>
                        </Stack>

                        <Stack direction="row" spacing={1} sx={{ display: "flex", alignItems: "center", flexGrow: 1 }}>
                            <Link to="/courses">
                                <Button variant='text' sx={{ color: "white" }}>
                                    Courses
                                </Button>
                            </Link>

                            {userRole == Roles.Student &&
                                <Link to="/my-courses">
                                    <Button variant='text' sx={{ color: "white" }}>
                                        My Courses
                                    </Button>
                                </Link>
                            }
                        </Stack>

                        {userRole == Roles.Guest &&
                            <Stack direction="row" spacing={2}>
                                <Button variant='text' color='inherit' onClick={() => navigate("/login")}>Login</Button>
                                <Button variant='outlined' color="inherit" onClick={() => navigate("/register")}>Register</Button>
                            </Stack>
                        }

                        {userRole == Roles.Student &&
                            <Stack direction="row" spacing={2}>
                                <Button variant='text' color="inherit" onClick={handleLogout}>Log out</Button>
                            </Stack>
                        }
                    </Toolbar>
                </Container>
            </AppBar>
        </Box>
    )
}

export default Navbar

{/* <IconButton
                        size="large"
                        edge="start"
                        color="inherit"
                        aria-label="menu"
                        sx={{ mr: 2 }}
                        >
                        <MenuIcon />
                        </IconButton> */}