import { useNavigate } from 'react-router-dom';
//mui components
import { Box, AppBar, Toolbar, IconButton, Typography, Button, Container, styled, Stack } from '@mui/material'
//icons
import MenuIcon from '@mui/icons-material/Menu';

const StyledToolbar = styled(Toolbar)({
    display: "flex",
    alignItems: "center",
    justifyContent: "space-between"
})

const Navbar = () => {
    const navigate = useNavigate()

    return (
        <Box
            position="sticky"
            top={0}
            sx={{
                flexGrow: 1,
                marginBottom: "64px"
            }}
        >
            <AppBar>
                <Container>
                    <StyledToolbar style={{ padding: 0 }}>

                        <Typography variant="h6">
                            Watch&Learn
                        </Typography>

                        <Stack direction="row" spacing={2}>
                            <Button variant='text' color="inherit" onClick={() => navigate("/register")}>Register</Button>
                            <Button variant='outlined' color='inherit' onClick={() => navigate("/login")}>Login</Button>
                        </Stack>

                    </StyledToolbar>
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