@echo off
chcp 65001 >nul
echo Unity 프로젝트 스크립트 문서화를 시작합니다...
echo.

REM Doxygen 실행
doxygen Doxyfile

if %ERRORLEVEL% EQU 0 (
    echo.
    echo 문서화가 성공적으로 완료되었습니다!
    echo 생성된 문서 위치: Documentation/html/index.html
    echo.
    echo 웹 브라우저에서 문서를 확인하려면 위 파일을 열어주세요.
) else (
    echo.
    echo 문서화 중 오류가 발생했습니다.
    echo Doxygen이 설치되어 있는지 확인해주세요.
)

pause
