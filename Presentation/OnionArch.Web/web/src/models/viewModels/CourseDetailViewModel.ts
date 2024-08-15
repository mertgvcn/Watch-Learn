import { CourseCommentDTO } from "../DTOs/CourseCommentDTO";
import { LessonDTO } from "../DTOs/LessonDTO";

export interface CourseDetailViewModel {
    id : number;
    title: string;
    shortDescription: string;
    description: string;
    price: number;
    imgUrl: string;
    teacherName: string;
    studentCount: number;
    lessonCount: number;
    totalLessonDurationInSeconds: number;
    lessons: LessonDTO[]
    courseComments: CourseCommentDTO[]
}