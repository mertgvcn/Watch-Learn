import { Box } from '@mui/material'
import React from 'react'

const CoursePreview = () => {
    return (
        //Bu kısma img yerine tanıtım videosu gelecek 
        <Box sx={{
            width: "300px",
            height: "200px",
            padding: "1px",
            boxSizing: "border-box",
            borderTopLeftRadius: "4px",
            borderTopRightRadius: "4px"
        }}>
            <img src={require("../../../../../../assets/images/video_overview.png")} alt="" style={{
                width: "100%",
                height: "100%",
                objectFit: "cover",
                borderTopLeftRadius: "4px",
                borderTopRightRadius: "4px"
            }} />
        </Box>
    )
}

export default CoursePreview