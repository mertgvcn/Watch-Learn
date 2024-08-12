import { LessonDTO } from "../DTOs/LessonDTO";
import { StudentDTO } from "../DTOs/StudentDTO";
import { TeacherDTO } from "../DTOs/TeacherDTO";

export interface CourseViewModel {
    id : number;
    title: string;
    shortDescription: string;
    description: string;
    totalLessonDuration: string;
    price: number;
    teacher: TeacherDTO;
    lessons: LessonDTO[];
    students: StudentDTO[];
}