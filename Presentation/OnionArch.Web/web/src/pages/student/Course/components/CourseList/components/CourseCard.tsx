import React from 'react'
//mui components
import { Box, Card, CardActions, CardContent, CardMedia, Divider, Stack, Typography } from '@mui/material'
//icons
import SubjectIcon from '@mui/icons-material/Subject';
import AccessTimeIcon from '@mui/icons-material/AccessTime';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';

const CourseCard = () => {
    return (
        <Card
            sx={{
                height: "fit-content",
                cursor: "pointer",
                transition: "transform 0.15s ease-in-out",
                "&:hover": {
                    transform: "scale(1.02)",
                }
            }}
        >
            <CardMedia
                sx={{ height: "160px", objectFit: "cover" }}
                image='https://www.datocms-assets.com/64859/1648564414-hafiza-teknikleri.jpg?q=70&auto=format&w=650&fit=max&iptc=allow'
            />
            <CardContent sx={{ display: "flex", flexDirection: "column", justifyContent: "space-between", paddingBottom: "8px" }}>
                <Box sx={{height: "50px"}}>
                    <Typography variant='button'>
                        Decision Making
                    </Typography>
                </Box>

                <Stack direction="row" spacing={2} sx={{ marginTop: "0.5rem" }}>
                    <Box sx={{ display: "flex", alignItems: "center", gap: "4px" }}>
                        <SubjectIcon sx={{ fontSize: 16 }} />
                        <Typography variant='caption'>
                            16 Lessons
                        </Typography>
                    </Box>

                    <Box sx={{ display: "flex", alignItems: "center", gap: "4px" }}>
                        <AccessTimeIcon sx={{ fontSize: 16 }} />
                        <Typography variant='caption'>
                            4 Hours
                        </Typography>
                    </Box>
                </Stack>
            </CardContent>

            <Divider variant='middle' />

            <CardActions>
                <Box sx={{ width: "100%", display: "flex", justifyContent: "space-between" }}>
                    <Stack direction="row" spacing={0.5}>
                        <AccountCircleIcon sx={{ fontSize: 22 }} />
                        <Typography variant='body2'>
                            Teacher Name
                        </Typography>
                    </Stack>

                    <Typography variant='subtitle2'>
                        450TL
                    </Typography>
                </Box>
            </CardActions>
        </Card>
    )
}

export default CourseCard