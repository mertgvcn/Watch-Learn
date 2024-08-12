import { Box, Container } from '@mui/material'
import React from 'react'

const Footer = () => {
    return (
        <Box sx={{
            backgroundColor: "rgb(35,35,35)",
            height: "200px",
            width: "100%",
            color: "white"
        }}>
            <Container>
                <Box sx={{
                    paddingY: "1rem",
                    boxSizing: "border-box"
                }}>
                    Footer
                </Box>
            </Container>
        </Box>
    )
}

export default Footer