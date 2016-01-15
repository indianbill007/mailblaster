using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using SocioBoardAccountEpiryMailSender.Domain;


namespace SocioBoardAccountEpiryMailSender.Helper
{
  class MailSender
    {
        public static string SendIvitationMail(string UserName, string toEmail, string mandrilEmail, string mandrilPass, string SenderName)
        {
            try
            {
                string html = "<html xmlns=\"http://www.w3.org/1999/xhtml\"><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\"><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0\">" +
                "<title>Freshmail Responsive E-mail Template - Mixed Layout Blue</title><style type=\"text/css\">html {width: 100%}::-moz-selection {background: #eb5600;color: #fff}::selection {background: #eb5600;color: #fff}" +
                "body {background-color: #f8f8f8;margin: 0;padding: 0}.ReadMsgBody {width: 100%;background-color: #f8f8f8}.ExternalClass {width: 100%;background-color: #f8f8f8}a {color: #eb5600;text-decoration: none;font-weight: 400;font-style: normal}" +
                "a:hover {color: #aaa;text-decoration: underline;font-weight: 400;font-style: normal}a.heading-link {text-decoration: none;font-weight: 400;font-style: normal}a.heading-link:hover {text-decoration: none;font-weight: 400;font-style: normal}" +
                "p,div {margin: 0!important}table {border-collapse: collapse}@media only screen and (max-width: 640px) {table table {width: 100%!important}td[class=full_width] {width: 100%!important}" +
                "div[class=div_scale] {width: 440px!important;margin: 0 auto!important}table[class=table_scale] {width: 440px!important;margin: 0 auto!important}td[class=td_scale] {width: 440px!important;margin: 0 auto!important}" +
                "img[class=img_scale] {width: 100%!important;height: auto!important}img[class=divider] {width: 440px!important;height: 2px!important}table[class=spacer] {display: none!important}td[class=spacer] {display: none!important}" +
                "td[class=center] {text-align: center!important}table[class=full] {width: 400px!important;margin-left: 20px!important;margin-right: 20px!important}img[class=divider] {width: 100%!important;height: 1px!important}}@media only screen and (max-width: 479px) {table table {width: 100%!important}td[class=full_width] {width: 100%!important}" +
                "div[class=div_scale] {width: 280px!important;margin: 0 auto!important}table[class=table_scale] {width: 280px!important;margin: 0 auto!important}td[class=td_scale] {width: 280px!important;margin: 0 auto!important}img[class=img_scale] {width: 100%!important;height: auto!important}" +
                "img[class=divider] {width: 280px!important;height: 2px!important}table[class=spacer] {display: none!important}td[class=spacer] {display: none!important}td[class=center] {text-align: center!important}table[class=full] {width: 240px!important;margin-left: 20px!important;margin-right: 20px!important}" +
                "img[class=divider] {width: 100%!important;height: 1px!important}}</style>" +
                "<style type=\"text/css\"></style></head><body bgcolor=\"#f8f8f8\"><table align=\"center\" bgcolor=\"#f8f8f8\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"margin-top: 20px;\"><tbody><tr>" +
                "<td valign=\"top\" width=\"100%\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\"><table bgcolor=\"#ffffff\" class=\"table_scale\" width=\"600\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">" +
                "<tbody><tr><td width=\"100%\" height=\"30\">&nbsp;</td></tr></tbody></table><table class=\"table_scale\" width=\"600\" bgcolor=\"#ffffff\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\"><table width=\"600\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">" +
                "<tbody><tr><td class=\"spacer\" width=\"30\"></td><td width=\"540\"><table class=\"full\" align=\"left\" width=\"255\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\">" +
                "<tbody><tr><td class=\"center\" align=\"left\" style=\"padding: 0px; text-transform: uppercase; font-family: Lucida Sans Unicode; color:#666666; font-size:24px; line-height:34px;\"> <span> <a href=\"#\" style=\"color:#eb5600;\"> <img src=\"http://www.socioboard.com/Themes/Socioboard/Contents/img/logo.png\" alt=\"logo\" width=\"250\" height=\"60\" border=\"0\" style=\"display: inline;\"> </a> </span> </td></tr></tbody>" +
                "</table><table width=\"25\" align=\"left\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tbody><tr><td width=\"100%\" height=\"30\"></td></tr>" +
                "</tbody></table><table class=\"full\" align=\"right\" width=\"255\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tbody>" +
                "<tr><td class=\"center\" align=\"right\" style=\"margin: 0; padding-top: 10px; text-transform: uppercase; font-size: 10px; color:#666666; font-family: Lucida Sans Unicode; line-height: 30px;  mso-line-height-rule: exactly;\"> <span> call us: +1 408 5209502, +91 80 41660003</span>" +
                "</td></tr></tbody></table></td><td class=\"spacer\" width=\"30\"></td></tr></tbody></table></td></tr></tbody></table><table bgcolor=\"#ffffff\" class=\"table_scale\" width=\"600\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\" height=\"30\">&nbsp;</td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><table align=\"center\" bgcolor=\"#f8f8f8\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td valign=\"top\" width=\"100%\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\"><table class=\"table_scale\" width=\"600\" bgcolor=\"#eb5600\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\">" +
                "<table width=\"600\" background=\"images/featured-bg.png\" bgcolor=\"#eb5600\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"600\" valign=\"middle\" style=\"padding: 0px;\"><table class=\"full\" align=\"center\" width=\"540\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tbody><tr><td width=\"100%\" height=\"30\">&nbsp;</td></tr><tr><td class=\"center\" align=\"center\" style=\"margin: 0; padding-bottom:15px; margin:0; text-transform: uppercase; font-family: Lucida Sans Unicode; font-size: 32px; color: #ffffff; line-height: 42px;mso-line-height-rule: exactly;\"> <span> HI [name],</span></td></tr><tr><td class=\"center\" align=\"center\" style=\"margin: 0; padding-bottom:15px; margin:0; text-transform: uppercase; font-family: Lucida Sans Unicode; font-size: 18px; color: #ffffff; line-height: 30px;mso-line-height-rule: exactly;\">" +
                "<span>your friend [SenderName] has invited you to try Socioboard.</span></td></tr><tr><td class=\"center\" align=\"center\" style=\"margin: 0; padding:0px; margin:0; font-size:13px ; color:#ffffff; font-family: Helvetica, Arial, sans-serif; line-height: 25px;mso-line-height-rule: exactly;\">" +
                "<span> Socioboard is a FREE and open source social media management and engagement platform which helps you generate more sales and acquire new customers on Social Media.<br>Thousands of social media enthusiasts like you are using Socioboard daily to interact and engage your audience in unique effortless ways.<br>Try Socioboard today and take your business to newer heights.<br> Do share your Socioboarding experience with us at <a href=\"http://www.socioboard.com/Index/contact\" target=\"_blank\" style=\"color:#ffeda4;\">http://www.socioboard.com/Index/contact</a> . <br>" +
                "You can also write to us on <strong>support@socioboard.com</strong> or join us on Skype at <strong>socioboard.support</strong>. <br>Happy Socioboarding! <br>Thanks </span> </td></tr><tr><td align=\"center\" valign=\"middle\" style=\"padding-top: 20px;\"><table border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"#ffffff\" style=\"margin: 0;\"><tbody><tr><td align=\"center\" valign=\"middle\" bgcolor=\"#ffffff\" style=\"padding: 8px 20px; text-transform: uppercase; color:#666666; font-size:18px ; color:#ffffff; font-family: Helvetica, Arial, sans-serif; line-height: 28px; mso-line-height-rule: exactly;\"> <a href=\"http://www.socioboard.com/\" target=\"_blank\" style=\"font-weight: normal; color:#444444; \"> Click here to use Socioboard absolutely free! </a> </td></tr></tbody></table></td></tr><tr>" +
                "<td width=\"100%\" height=\"30\">&nbsp;</td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><table align=\"center\" bgcolor=\"#f8f8f8\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td valign=\"top\" width=\"100%\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody>" +
                "<tr><td width=\"100%\"><table bgcolor=\"#dddddd\" class=\"table_scale\" width=\"600\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\" height=\"30\">&nbsp;</td</tr></tbody></table><table class=\"table_scale\" width=\"600\" bgcolor=\"#dddddd\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\">" +
                "<table width=\"600\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td class=\"spacer\" width=\"30\"></td><td width=\"540\"><table class=\"full\" align=\"left\" width=\"160\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tbody><tr><td class=\"center\" align=\"left\" style=\"margin: 0; font-size:14px ; color:#aaaaaa; font-family: Helvetica, Arial, sans-serif; line-height: 24px;\"> <span> <a href=\"http://www.socioboard.com\" target=\"_blank\" style=\"color:#eb5600;\"> <img class=\"img_scale\" src=\"http://www.socioboard.com/Themes/Socioboard/Contents/img/slidegraph.png\" alt=\"portfolio_1\" width=\"160\" height=\"100\" border=\"0\" style=\"display: block;\"> </a> </span> </td></tr></tbody></table><table width=\"30\" align=\"left\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tbody><tr><td width=\"100%\" height=\"30\"></td>" +
                "</tr></tbody></table><table class=\"full\" align=\"left\" width=\"160\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tbody><tr><td class=\"center\" align=\"left\" style=\"margin: 0; font-size:14px ; color:#aaaaaa; font-family: Helvetica, Arial, sans-serif; line-height: 24px;\"> <span> <a href=\"http://www.socioboard.com\" target=\"_blank\" style=\"color:#eb5600;\"> <img class=\"img_scale\" src=\"http://www.socioboard.com/Themes/Socioboard/Contents/img/ssp/phone-banner.png\" alt=\"portfolio_2\" width=\"160\" height=\"100\" border=\"0\" style=\"display: block;\"> </a> </span> </td></tr></tbody></table><table width=\"20\" align=\"left\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tbody>" +
                "<tr><td width=\"100%\" height=\"30\"></td></tr></tbody></table><table class=\"full\" align=\"right\" width=\"160\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tbody><tr><td class=\"center\" align=\"left\" style=\"margin: 0; font-size:14px ; color:#aaaaaa; font-family: Helvetica, Arial, sans-serif; line-height: 24px;\"> <span> <a href=\"http://www.socioboard.com\" target=\"_blank\" style=\"color:#eb5600;\"> <img class=\"img_scale\" src=\"http://www.socioboard.com/Themes/Socioboard/Contents/img/ssp/img-1.png\" alt=\"portfolio_3\" width=\"160\" height=\"100\" border=\"0\" style=\"display: block;\"> </a> </span> </td></tr></tbody></table></td><td class=\"spacer\" width=\"30\"></td>" +
                "</tr></tbody></table></td></tr></tbody></table><table bgcolor=\"#dddddd\" class=\"table_scale\" width=\"600\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\" height=\"30\">&nbsp;</td></tr></tbody></table><table bgcolor=\"#ffffff\" class=\"table_scale\" width=\"600\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\" height=\"40\">&nbsp;</td></tr>" +
                "</tbody></table></td></tr></tbody></table></td></tr></tbody></table><table align=\"center\" bgcolor=\"#f8f8f8\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td valign=\"top\" width=\"100%\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\">" +
                "<table class=\"table_scale\" width=\"600\" bgcolor=\"#ffffff\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">" +
                "<tbody><tr><td width=\"100%\"><table width=\"600\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td class=\"spacer\" width=\"30\"></td><td width=\"540\"><table class=\"full\" align=\"left\" width=\"540\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tbody><tr><td class=\"center\" align=\"center\" style=\"padding-bottom: 10px; text-transform: uppercase; font-family: Lucida Sans Unicode; color:#666666; font-size:24px; line-height:34px; mso-line-height-rule: exactly;\"> <span> Our Esteemed Clientele ... </span> </td></tr></tbody></table><table class=\"full\" align=\"center\" width=\"160\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tbody>" +
                "<tr><td class=\"center\" align=\"center\" style=\"margin: 0; padding: 0px; font-size:14px ; color:#aaaaaa; font-family: Helvetica, Arial, sans-serif; line-height: 24px;\"> <span> <a target=\"_blank\" href=\"#\" style=\"color:#eb5600;\"> <img src=\"http://www.socioboard.com/Themes/Socioboard/Contents/img/re_store_logos.png\" alt=\"blue\" width=\"600\" height=\"200\" border=\"0\" style=\"display: inline;\"> </a></span> </td></tr></tbody></table></td><td class=\"spacer\" width=\"30\"></td></tr></tbody></table></td></tr></tbody></table><table bgcolor=\"#ffffff\" class=\"table_scale\" width=\"600\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\" height=\"40\">&nbsp;</td></tr></tbody></table>" +
                "</td></tr></tbody></table></td></tr></tbody></table><table align=\"center\" bgcolor=\"#f8f8f8\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td valign=\"top\" width=\"100%\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\">" +
                "<tbody><tr><td width=\"100%\"><table class=\"table_scale\" width=\"600\" bgcolor=\"#ffffff\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\"><table width=\"600\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td align=\"center\" style=\"margin: 0; font-size:14px ; color:#aaaaaa; font-family: Helvetica, Arial, sans-serif; line-height: 0;\"> <span> <img class=\"divider\" src=\"images/divider-image.png\" alt=\"divider image\" width=\"600\" height=\"1\" border=\"0\" style=\"display: block;\"> </span> </td>" +
                "</tr></tbody></table></td></tr></tbody></table><table bgcolor=\"#ffffff\" class=\"table_scale\" width=\"600\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\" height=\"40\">&nbsp;</td></tr></tbody></table></td></tr></tbody></table></td></tr>" +
                "</tbody></table><table align=\"center\" bgcolor=\"#f8f8f8\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td valign=\"top\" width=\"100%\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\"><table class=\"table_scale\" width=\"600\" bgcolor=\"#ffffff\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr>" +
                "<td width=\"100%\"><table width=\"600\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td class=\"spacer\" width=\"30\"></td><td width=\"540\"><table class=\"full\" align=\"left\" width=\"540\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tbody><tr><td class=\"center\" align=\"center\" style=\"padding-bottom: 10px; text-transform: uppercase; font-family: Lucida Sans Unicode; color:#666666; font-size:24px; line-height:34px; mso-line-height-rule: exactly;\"> <span> WHAT ARE YOU WAITING FOR? </span> </td></tr><tr><td align=\"center\" valign=\"top\" style=\"padding-top: 15px;\"><table border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"#eb5600\" style=\"margin: 0;\"><tbody><tr>" +
                "<td align=\"center\" valign=\"middle\" bgcolor=\"#eb5600\" style=\"padding: 5px 20px; text-transform: uppercase; font-size:14px; line-height: 24px; font-family:Arial, sans-serif; mso-line-height-rule: exactly;\">" +
                "<a href=\"http://www.socioboard.com/Index/Pricing\" target=\"_blank\" style=\"font-weight: normal; color:#ffffff; \"> <b>Try it now!</b> </a></td></tr></tbody></table></td></tr></tbody>" +
                "</table></td><td class=\"spacer\" width=\"30\"></td></tr></tbody></table></td></tr></tbody></table><table bgcolor=\"#ffffff\" class=\"table_scale\" width=\"600\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\" height=\"40\">&nbsp;</td></tr></tbody></table></td></tr></tbody></table></td>" +
                "</tr></tbody></table><table align=\"center\" bgcolor=\"#f8f8f8\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td valign=\"top\" width=\"100%\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\"><table bgcolor=\"#ededed\" class=\"table_scale\" width=\"600\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\" height=\"30\">&nbsp;</td></tr></tbody></table><table class=\"table_scale\" width=\"600\" bgcolor=\"#ededed\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\"><table width=\"600\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td class=\"spacer\" width=\"30\"></td><td width=\"540\">" +
                "<table class=\"full\" align=\"left\" width=\"255\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tbody><tr><td class=\"center\" align=\"left\" style=\"margin: 0;  text-transform: uppercase; font-size: 20px; color:#666666; font-family: Lucida Sans Unicode; line-height: 30px;  mso-line-height-rule: exactly;\"> <span> FOLLOW US ONLINE:</span> </td></tr></tbody></table><table width=\"25\" align=\"left\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tbody><tr><td width=\"100%\" height=\"30\"></td></tr></tbody></table>" +
                "<table class=\"full\" align=\"right\" width=\"300\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tbody><tr><td class=\"center\" align=\"right\" style=\"margin: 0; font-size:14px ; color:#aaaaaa; font-family: Helvetica, Arial, sans-serif; line-height: 100%;\"> <span> <a href=\"https://www.facebook.com/SocioBoard\" target=\"_blank\"><img src=\"http://i.imgur.com/mrfZQKf.png?1\" style=\"max-height: 70px;\"></a> &nbsp;<a href=\"https://twitter.com/Socioboard\" target=\"_blank\"><img src=\"http://i.imgur.com/gSA8HbM.png?1\" style=\"max-height: 70px;\"></a>  &nbsp;" +
                "<a href=\"https://plus.google.com/b/105412765098773776122/105412765098773776122/posts\" target=\"_blank\"><img src=\"http://i.imgur.com/EseCwni.png?1\" style=\"max-height: 70px;\"></a></span> </td></tr></tbody></table></td><td class=\"spacer\" width=\"30\"></td></tr></tbody></table></td></tr></tbody></table><table bgcolor=\"#ededed\" class=\"table_scale\" width=\"600\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr>" +
                "<td width=\"100%\" height=\"30\">&nbsp;</td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><table align=\"center\" bgcolor=\"#f8f8f8\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td valign=\"top\" width=\"100%\">" +
                "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\"><table bgcolor=\"#666666\" class=\"table_scale\" width=\"600\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\" height=\"30\">&nbsp;</td></tr></tbody></table><table class=\"table_scale\" width=\"600\" bgcolor=\"#666666\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\"><table width=\"600\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"600\"><table class=\"full\" align=\"center\" width=\"540\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\">" +
                "<tbody><tr><td class=\"center\" align=\"center\" style=\"margin: 0;  font-size:12px ; color:#ededed; font-family: Helvetica, Arial, sans-serif; line-height: 18px;\"> <span> We doubled our revenues from the leads acquired with the help of Socioboard. <a target=\"_blank\" href=\"#\" style=\"color:#FDAA7A;\"> - Mahmoudou Sidibe, US</a></span> </td></tr><tr>" +
                "<td class=\"center\" align=\"center\" style=\"margin: 0;  font-size:12px ; color:#ededed; font-family: Helvetica, Arial, sans-serif; line-height: 18px;\"> <span> Socioboard has helped us understand our customers better, target them better and increase overall ROI per customer. <a target=\"_blank\" href=\"#\" style=\"color:#FDAA7A;\"> - Sarim Ali, US</a></span> </td></tr><tr><td class=\"center\" align=\"center\" style=\"margin: 0;  font-size:12px ; color:#ededed; font-family: Helvetica, Arial, sans-serif; line-height: 18px;\"> <span> Support at Socioboard is excellent, they are online 24/7 and respond to tickets within minutes. <a target=\"_blank\" href=\"#\" style=\"color:#FDAA7A;\"> - Adam Prosmith, UK</a></span> </td></tr>" +
                "<tr><td class=\"center\" align=\"center\" style=\"margin: 0;  font-size:12px ; color:#ededed; font-family: Helvetica, Arial, sans-serif; line-height: 18px;\"> <span> Our sales shot over the roof after we started using Socioboard to target customers on Social Media. <a target=\"_blank\" href=\"#\" style=\"color:#FDAA7A;\"> - Christopher Sutch, US</a></span> </td></tr><tr><td class=\"center\" align=\"center\" style=\"margin: 0;  font-size:12px ; color:#ededed; font-family: Helvetica, Arial, sans-serif; line-height: 18px;\"> <span> Makes life easy and less cumbersome with smart social inbox. Thanks Socioboard. <a target=\"_blank\" href=\"#\" style=\"color:#FDAA7A;\"> - Maya Ross, UK</a></span> </td></tr></tbody></table></td>" +
                "</tr></tbody></table></td></tr></tbody></table><table bgcolor=\"#666666\" class=\"table_scale\" width=\"600\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\" height=\"20\">&nbsp;</td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><table align=\"center\" bgcolor=\"#f8f8f8\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr>" +
                "<td valign=\"top\" width=\"100%\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\"><table bgcolor=\"#666666\" class=\"table_scale\" width=\"600\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"border-top: 1px solid #767373;\">" +
                "<tbody><tr><td width=\"100%\" height=\"20\">&nbsp;</td></tr></tbody></table><table bgcolor=\"#666666\" class=\"table_scale\" width=\"600\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody>" +
                "<tr><td width=\"100%\" height=\"20\">&nbsp;</td></tr></tbody></table><table bgcolor=\"#f8f8f8\" class=\"table_scale\" width=\"600\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\" height=\"30\">&nbsp;</td></tr></tbody></table></td></tr></tbody></table></td>" +
                "</tr></tbody></table><script>$(document).ready(function () {(function (i, s, o, g, r, a, m) {i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {(i[r].q = i[r].q || []).push(arguments)}, i[r].l = 1 * new Date(); a = s.createElement(o),m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)})(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');ga('require', 'displayfeatures');ga('create', 'UA-47199078-1', 'socioboard.com');ga('send', 'pageview');});</script></body></html>";
                UserName = UserName == "N/A" || UserName == "none" ? "" : UserName;
                html = html.Replace("[name]", UserName);
                html = html.Replace("[SenderName]", SenderName);

                string Host = "smtp.mandrillapp.com";
                int port = 587;

                string subject = "You have been invited to Socioboard by " + SenderName;
                string rtn = MailHelper.SendMailByMandrill(Host, port, mandrilEmail, mandrilPass, toEmail, subject, html, SenderName);
                string rtnstr = html + "####" + subject + "####" + UserName + "####" + mandrilEmail + "####" + toEmail;
                if (rtn == "Success")
                {
                    return rtnstr;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        public static string SendIvitationMailForNew(string UserName, string toEmail, string mandrilEmail, string mandrilPass, string SenderName)
        {
            try
            {
                string html = "<html xmlns=\"http://www.w3.org/1999/xhtml\"><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\"><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0\">" +
                        "<title>Freshmail</title><style type=\"text/css\">" +
                        "html {width: 100%}::-moz-selection {background: #eb5600;color: #fff}::selection {background: #eb5600;color: #fff}body {background-color: #f8f8f8;margin: 0;padding: 0}" +
                        ".ReadMsgBody {width: 100%;background-color: #f8f8f8}.ExternalClass {width: 100%;background-color: #f8f8f8}a {color: #eb5600;text-decoration: none;font-weight: 400;" +
                        "font-style: normal}a:hover {color: #aaa;text-decoration: underline;font-weight: 400;\font-style: normal}a.heading-link {text-decoration: none;font-weight: 400;font-style: normal}" +
                        "a.heading-link:hover {text-decoration: none;font-weight: 400;font-style: normal}p,div {margin: 0!important}table {border-collapse: collapse}@media only screen and (max-width: 640px)" +
                        "{table table {width: 100%!important}td[class=full_width] {width: 100%!important}div[class=div_scale] {width: 440px!important;margin: 0 auto!important}table[class=table_scale] {width: 440px!important;margin: 0 auto!important}" +
                        "td[class=td_scale] {width: 440px!important;margin: 0 auto!important}img[class=img_scale] {width: 100%!important;height: auto!important}img[class=divider] {width: 440px!important;height: 2px!important}" +
                        "table[class=spacer] {display: none!important}td[class=spacer] {display: none!important}td[class=center] {text-align: center!important}table[class=full] {width: 400px!important;margin-left: 20px!important;margin-right: 20px!important}" +
                        "img[class=divider] {width: 100%!important;height: 1px!important}}@media only screen and (max-width: 479px) {table table {width: 100%!important}td[class=full_width] {width: 100%!important}div[class=div_scale] {width: 280px!important;margin: 0 auto!important}" +
                        "table[class=table_scale] {width: 280px!important;margin: 0 auto!important}td[class=td_scale] {width: 280px!important;margin: 0 auto!important}img[class=img_scale] {width: 100%!important;height: auto!important}img[class=divider] {width: 280px!important;height: 2px!important}" +
                        "table[class=spacer] {display: none!important}td[class=spacer] {display: none!important}td[class=center] {text-align: center!important}table[class=full] {width: 240px!important;margin-left: 20px!important;margin-right: 20px!important}" +
                        "img[class=divider] {width: 100%!important;height: 1px!important}}</style><style type=\"text/css\"></style></head>" +
                        "<body bgcolor=\"#f8f8f8\"><table align=\"center\" bgcolor=\"#f8f8f8\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"margin-top: 20px;\"><tbody><tr><td valign=\"top\" width=\"100%\">" +
                        "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\"><table bgcolor=\"#ffffff\" class=\"table_scale\" width=\"600\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">" +
                        "<tbody><tr><td width=\"100%\" height=\"30\">&nbsp;</td></tr></tbody></table><table class=\"table_scale\" width=\"600\" bgcolor=\"#ffffff\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">" +
                        "<tbody><tr><td width=\"100%\"><table width=\"600\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td class=\"spacer\" width=\"30\"></td><td width=\"540\"><!-- START OF LOGO IMAGE TABLE-->" +
                        "<table class=\"full\" align=\"center\" width=\"255\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tbody><tr>" +
                        "<td class=\"center\" align=\"left\" style=\"padding: 0px; text-transform: uppercase; font-family: Lucida Sans Unicode; color:#666666; font-size:24px; line-height:34px;\"> <span> <a href=\"#\" style=\"color:#eb5600;\">" +
                        "<img src=\"http://www.socioboard.com/Themes/Socioboard/Contents/img/logo.png\" alt=\"logo\" width=\"250\" height=\"50\" border=\"0\" style=\"display: inline;\"> </a> </span> </td></tr></tbody></table>" +
                        "<!--<table width=\"25\" align=\"left\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tbody><tr><td width=\"100%\" height=\"30\"></td></tr></tbody></table> -->" +
                        "</td><td class=\"spacer\" width=\"30\"></td></tr></tbody></table></td></tr></tbody></table><table bgcolor=\"#ffffff\" class=\"table_scale\" width=\"600\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr>" +
                        "<td width=\"100%\" height=\"30\">&nbsp;</td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><table align=\"center\" bgcolor=\"#f8f8f8\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr>" +
                        "<td valign=\"top\" width=\"100%\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\"><table class=\"table_scale\" width=\"600\" bgcolor=\"#ffffff\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr>" +
                        "<td width=\"100%\"><table width=\"600\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td class=\"spacer\" width=\"30\"></td><td width=\"540\"><table class=\"full\" align=\"center\" width=\"160\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\">" +
                        "<tbody><tr><td class=\"center\" align=\"center\" style=\"margin: 0; padding: 0px; font-size:14px ; color:#aaaaaa; font-family: Helvetica, Arial, sans-serif; line-height: 24px;\"> <span> <a target=\"_blank\" href=\"http://www.socioboard.com/\" style=\"color:#eb5600;\"> <img src=\"http://i.imgur.com/Wb75rYQ.png?1\" alt=\"blue\" width=\"600\" height=\"200\" border=\"0\" style=\"display: inline;\">" +
                        "</a></span></td></tr></tbody></table></table></td><td class=\"spacer\" width=\"30\"></td></tr></tbody></table></td></tr></tbody></table><table bgcolor=\"#ffffff\" class=\"table_scale\" width=\"600\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\" height=\"40\">&nbsp;</td></tr></tbody></table>" +
                        "</td></tr></tbody></table></td></tr></tbody></table><table align=\"center\" bgcolor=\"#f8f8f8\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td valign=\"top\" width=\"100%\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\"><table class=\"table_scale\" width=\"600\" bgcolor=\"#dddddd\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">" +
                        "<tbody><tr><td width=\"100%\"><table width=\"600\" bgcolor=\"#6E6E6E\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><!--[if gte mso 9]> <v:rect xmlns:v=\"urn:schemas-microsoft-com:vml\" fill=\"true\" stroke=\"false\" style=\"width:600px;height:315px;\"> <v:fill type=\"tile\" src=\"http://i.imgur.com/5Udx4T6.png\" color=\"#eb5600\" /> <v:textbox inset=\"0,0,0,0\"> <![endif]-->" +
                        "<tbody><tr><td width=\"600\" valign=\"middle\" style=\"padding: 0px;\"><table class=\"full\" align=\"center\" width=\"540\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tbody><tr><td width=\"100%\" height=\"30\">&nbsp;</td></tr>" +
                        "<tr><td class=\"center\" align=\"center\" style=\"margin: 0; padding-bottom:15px; margin:0; text-transform: uppercase; font-family: Lucida Sans Unicode; font-size: 14px; color: #ffffff; line-height: 20px;mso-line-height-rule: exactly;\"> <span>SocioQueue has unique features which you won't find anywhere else. Best part is its all available in our open-source package.</span></td></tr>" +
                        "<tr><td style=\"padding-top: 30px;\"><table width=\"100%\" border=\"0\"  cellspacing=\"0\" cellpadding=\"0\"><tbody><tr><td width=\"100\" class=\"img\" style=\"font-size:0pt; line-height:0pt; text-align:left\"><a target=\"_blank\" href=\"#\"><img src=\"http://i.imgur.com/cEIuVLn.png\" width=\"60\" height=\"56\" border=\"0\" alt=\"\"></a></td>" +
                        "<td class=\"text-small\" style=\"font-family:Tahoma; font-size:13px; line-height:18px; text-align:left; color:#ffffff\"><div class=\"h2-2\" style=\"font-family:Tahoma, sans-serif; font-size:16px; line-height:18px; font-weight:bold; padding: 0 0 10; color:#ffffff\">Custom settings</div>Queue is now highly customizable profile by profile and is highly suitable for audiences with unique taste." +
                        "</td></tr></tbody></table> </td></tr><tr><td style=\"padding-top: 30px;\"><table width=\"100%\" border=\"0\"  cellspacing=\"0\" cellpadding=\"0\"><tbody><tr><td width=\"100\" class=\"img\" style=\"font-size:0pt; line-height:0pt; text-align:left\"><a target=\"_blank\" href=\"#\">" +
                        "<img src=\"http://i.imgur.com/fGr68Yy.png?1\" width=\"60\" height=\"56\" border=\"0\" alt=\"\"></a></td><td class=\"text-small\" style=\"font-family:Tahoma; font-size:13px; line-height:18px; text-align:left; color:#ffffff\"><div class=\"h2-2\" style=\"font-family:Tahoma, sans-serif; font-size:16px; line-height:18px; font-weight:bold; padding: 0 0 10; color:#ffffff\">" +
                        "Smart timeline</div>See your posts as draft and edit and fill gaps as required before firing your arrows.</td></tr></tbody></table></td></tr><tr><td style=\"padding-top: 30px;\"><table width=\"100%\" border=\"0\"  cellspacing=\"0\" cellpadding=\"0\"><tbody><tr><td width=\"100\" class=\"img\" style=\"font-size:0pt; line-height:0pt; text-align:left\">" +
                        "<a target=\"_blank\" href=\"#\"><img src=\"http://i.imgur.com/iLJLF97.png?1\" width=\"60\" height=\"56\" border=\"0\" alt=\"\"></a></td><td class=\"text-small\" style=\"font-family:Tahoma; font-size:13px; line-height:18px; text-align:left; color:#ffffff\">" +
                        "<div class=\"h2-2\" style=\"font-family:Tahoma, sans-serif; font-size:16px; line-height:18px; font-weight:bold; padding: 0 0 10; color:#ffffff\">Set and Go!</div>Schedule your posts for profiles and the content gets posted automatically from the queue.</td></tr></tbody></table> </td></tr>" +
                        "<tr><td align=\"center\" valign=\"middle\" style=\"padding-top: 20px;\"><table border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"#ffffff\" style=\"margin: 0;\"><tbody><tr>" +
                        "<td align=\"center\" valign=\"middle\" bgcolor=\"#ffffff\" style=\"padding: 8px 20px; text-transform: uppercase; color:#666666; font-size:18px ; color:#ffffff; font-family: Helvetica, Arial, sans-serif; line-height: 28px; mso-line-height-rule: exactly;\">" +
                        "<a href=\"http://www.socioboard.com\" target=\"_blank\" style=\"font-weight: normal; color:#444444; \"> FIND OUT MORE </a> </td></tr></tbody></table></td></tr>" +
                        "<tr><td width=\"100%\" height=\"30\">&nbsp;</td></tr></tbody></table></td></tr><!--[if gte mso 9]> </v:textbox> </v:rect> <![endif]--></tbody></table></td></tr></tbody>" +
                        "</table></td></tr></tbody></table></td></tr></tbody></table><table align=\"center\" bgcolor=\"#f8f8f8\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td valign=\"top\" width=\"100%\">" +
                        "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\"><table bgcolor=\"#dddddd\" class=\"table_scale\" width=\"600\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">" +
                        "<tbody><!-- START OF BUTTON--><tr><td align=\"center\" valign=\"middle\" style=\"padding-top: 20px;\"><table border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"style=\"margin: 0;\"><tbody><tr>" +
                        "<td width=\"100\" class=\"img\" style=\"font-size:0pt; line-height:0pt; text-align:left\"><a target=\"_blank\" href=\"#\"><img src=\"http://i.imgur.com/yubWZFL.png\" width=\"60\" height=\"56\" border=\"0\" alt=\"\"></a></td></tr></tbody></table></td></tr>" +
                        "<tr><td align=\"center\" valign=\"middle\" style=\"padding-top: 20px;\"><table border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"style=\"margin: 0;\"><tbody><tr><td class=\"center\" align=\"center\" style=\"margin: 0;  font-size:14px ; color:#000000; font-family: Helvetica, Arial, sans-serif; line-height: 18px;\"> <span>Stay connected for tips and tricks</span>" +
                        "</td></tr></tbody></table></td></tr><tr><td width=\"100%\" height=\"30\">&nbsp;</td></tr><tr><td class=\"center\" align=\"center\" style=\"margin: 0; font-size:14px ; color:#aaaaaa; font-family: Helvetica, Arial, sans-serif; line-height: 100%;\"> <span> <a href=\"https://www.facebook.com/SocioBoard\" target=\"_blank\"><img src=\"http://i.imgur.com/mrfZQKf.png?1\" style=\"max-height: 50px;\">" +
                        "</a> &nbsp;<a href=\"https://twitter.com/Socioboard\" target=\"_blank\"><img src=\"http://i.imgur.com/gSA8HbM.png?1\" style=\"max-height: 50px;\"></a>&nbsp;<a href=\"https://plus.google.com/b/105412765098773776122/105412765098773776122/posts\" target=\"_blank\"><img src=\"http://i.imgur.com/EseCwni.png?1\" style=\"max-height: 50px;\"></a></span></td></tr>" +
                        "<tr><td align=\"center\" valign=\"middle\" style=\"padding-top: 20px;\"><table border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"style=\"margin: 0;\"><tbody></tbody></table></td></tr></tbody></table><table bgcolor=\"#dddddd\" class=\"table_scale\" width=\"600\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">" +
                        "<tbody><tr><td class=\"center\" align=\"center\" style=\"margin: 0;  font-size:14px ; color:#000000; font-family: Helvetica, Arial, sans-serif; line-height: 18px;\"> <span>L V Complex, 2nd Floor, No.58, 7th Block, 80 Feet Road, Koramangala – 560095 Bangalore, Karnataka, India</span> </td></tr><tr><td width=\"100%\" height=\"30\">&nbsp;</td></tr></tbody></table>" +
                        "</td></tr></tbody></table></td></tr></tbody></table>   <table align=\"center\" bgcolor=\"#f8f8f8\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td valign=\"top\" width=\"100%\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\">" +
                        "<table bgcolor=\"#666666\" class=\"table_scale\" width=\"600\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"border-top: 1px solid #767373;\"><tbody><tr><td width=\"100%\" height=\"20\">&nbsp;</td></tr></tbody></table>" +
                        "<table bgcolor=\"#666666\" class=\"table_scale\" width=\"600\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\" height=\"20\">&nbsp;</td></tr></tbody></table>" +
                        "<table bgcolor=\"#f8f8f8\" class=\"table_scale\" width=\"600\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td width=\"100%\" height=\"30\">&nbsp;</td></tr></tbody>" +
                        "</table></td></tr></tbody></table></td></tr></tbody></table></body></html>";
                UserName = UserName == "N/A" || UserName == "none" ? "" : UserName;
                html = html.Replace("[name]", UserName);
                html = html.Replace("[SenderName]", SenderName);

                string Host = "smtp.mandrillapp.com";
                int port = 587;

                string subject = "Schedule and Automate your social media posts with SocioQueue from Socioboard";
                string rtn = MailHelper.SendMailByMandrill(Host, port, mandrilEmail, mandrilPass, toEmail, subject, html, SenderName);
                string rtnstr = html + "####" + subject + "####" + UserName + "####" + mandrilEmail + "####" + toEmail;
                if (rtn == "Success")
                {
                    return rtnstr;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        public static string SendAccountExpiryMail(string UserName, string toEmail, string MandrillEmail, string MandrillPass, string SenderName)
        {
            string html = "<!DOCTYPE html PUBLIC><html lang=\"en\"><head>" +
            "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />" +
            "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">" +
            "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge,chrome=1\">" +
            "<meta name=\"format-detection\" content=\"telephone=no\" /><title>Account Expiry Email - SocioBoard</title>" +
            "<link rel=\"stylesheet\" href=\"email.css\" />" +
            "<style>body {font-family: \"Source Sans Pro\",\"Helvetica Neue\",Helvetica,Arial,sans-serif;}</style></head>" +
            "<body bgcolor=\"#E1E1E1\" leftmargin=\"0\" marginwidth=\"0\" topmargin=\"0\" marginheight=\"0\" offset=\"0\"><center style=\"background-color:#E1E1E1;\">" +
            "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" height=\"100%\" width=\"100%\" id=\"bodyTable\" style=\"table-layout: fixed;max-width:100% !important;width: 100% !important;min-width: 100% !important;\">" +
            "<tr><td align=\"center\" valign=\"top\" id=\"bodyCell\">" +
            "<table bgcolor=\"#FFFFFF\"  border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"700\" id=\"emailBody\"><tr><td align=\"center\" valign=\"top\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" bgcolor=\"#fff\">" +
            "<tr><td align=\"center\" valign=\"top\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"500\" class=\"flexibleContainer\"><tr><td align=\"center\" valign=\"top\" width=\"500\" class=\"flexibleContainerCell\">" +
            "<table border=\"0\" cellpadding=\"30\" cellspacing=\"0\" width=\"100%\"><tr><td align=\"center\" valign=\"top\" class=\"textContent\"><center><img src=\"http://www.socioboard.com/Themes/Socioboard/Contents/img/logo.png\" /></center></td></tr></table></td></tr></table></td></tr></table></td></tr>" +
            "<tr><td align=\"center\" valign=\"top\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" bgcolor=\"#ffaa7b\">" +
            "<tr style=\"padding-top:0;\"><td align=\"center\" valign=\"top\"><table border=\"0\" cellpadding=\"30\" cellspacing=\"0\" width=\"700\" class=\"flexibleContainer\"><tr><td style=\"padding-top:0;\" align=\"center\" valign=\"top\" width=\"500\" class=\"flexibleContainerCell\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"90%\" style=\"margin-top:10%;\"><tr><td align=\"left\"><p>Hi [UserName],</p></td></tr>" +
            "<tr><td align=\"left\"><p style=\"margin-top: 7%;\">Your free trial is ending today.</p></td></tr>" +
            "<tr><td align=\"left\"><p style=\"margin-top: 5%;\">Don't get sad, you can upgrade and keep using it or downgrade to basic version in no time.</p></td></tr>" +
            "<tr><td align=\"left\"><p style=\"margin-top: 5%;\">If you have any questions, let us know..</p></td></tr><tr><td align=\"left\">" +
            "<p style=\"margin-top: 10%; margin-bottom:5%;\">Sincerely,<br/>Support Team,<br/>Socioboard.</p></td></tr></table></td></tr></table></td></tr></table></td></tr></table>" +
            "<table bgcolor=\"#E1E1E1\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"500\" id=\"emailFooter\"><tr><td align=\"center\" valign=\"top\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">" +
            "<tr><td align=\"center\" valign=\"top\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"500\" class=\"flexibleContainer\"><tr>" +
            "<td align=\"center\" valign=\"top\" width=\"500\" class=\"flexibleContainerCell\"><table border=\"0\" cellpadding=\"30\" cellspacing=\"0\" width=\"100%\"><tr><td valign=\"top\" bgcolor=\"#E1E1E1\">" +
            "<div style=\"font-family:Helvetica,Arial,sans-serif;font-size:13px;color:#828282;text-align:center;line-height:120%;\">" +
            "<div>Copyright &copy; 2015 <a href=\"#\" target=\"_blank\" style=\"text-decoration:none;color:#828282;\"><span style=\"color:#828282;\">Socioboard</span></a>. All&nbsp;rights&nbsp;reserved.</div>" +
            "<div>If you do not want to recieve emails from us, you can <a href=\"#\" target=\"_blank\" style=\"text-decoration:none;color:#828282;\"><span style=\"color:#828282;\">unsubscribe</span></a>.</div>" +
            "</div></td></tr></table></td></tr></table></td></tr></table></td></tr></table></td></tr></table></center></body></html>";
            html = html.Replace("[UserName]", UserName);
            string Host = "smtp.mandrillapp.com";
            int port = 587;
            string subject = "Account Expiry Notification";
            string rtn = MailHelper.SendMailByMandrill(Host, port, MandrillEmail, MandrillPass, toEmail, subject, html, SenderName);
            if (rtn == "Success")
            {
                return rtn;
            }
            else
            {
                return null;
            }
        }

        public static string SendBlogmail(string UserName, string toEmail, string MandrillEmail, string MandrillPass, string SenderName)
        {
            string html = "<!DOCTYPE html><html lang=\"en\"><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><title>Email Template</title>" +
            "<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.2/css/bootstrap.min.css\" />" +
            "<style>body {font-family:\"Segoe UI\";	background-color:#eff3f6;}</style></head><body><div class=\"container\" style=\"margin-top: 1.5%;\">" +
            "<div class=\"row\"><div class=\"col-md-6 col-md-offset-3\"><div class=\"panel\"><div class=\"panel-heading row\"><div class=\"col-md-9\" style=\"margin-top:2%;\">" +
            "<img src=\"http://i.imgur.com/mMqJj0z.png\" alt=\"SocioBoard\"><br/>&nbsp;</div><div class=\"col-md-3\" style=\"margin-top:3%;\">" +
            "<a href=\"https://www.facebook.com/SocioBoard\" style=\"text-decoration: none\" target=\"_blank\"><img src=\"http://i.imgur.com/tJumoLd.png\" alt=\"Like us on Facebook\">" +
            "</a><a href=\"https://twitter.com/Socioboard\" style=\"text-decoration: none\" target=\"_blank\"><img src=\"http://i.imgur.com/KLMlRoB.png\" alt=\"Follow us on Twitter\"></a>" +
            "<!--  <a href=\"#\" style=\"text-decoration: none\"><img src=\"http://i.imgur.com/YSivij0.png\" alt=\"Follow our LinkedIn\"></a>--></div></div><div class=\"panel-body\" style=\"color:#3F3D51;\"><div class=\"panel panel-default\"><div class=\"panel-body\"><div class=\"row\">" +
            "<div class=\"col-md-12\"><h3 style=\"color: #3F3D51;\">Hi [UserName], </h3><p style=\"color: #3F3D51; font: 15px/1.5em 'Open Sans','Helvetica Neue', arial, sans-serif; margin: 0 0 1em;\">" +
            "Passing by to invite you to keep in touch with us via the Socioboard Blog & Twitter channels at - <a href=\"http://blog.socioboard.com/\" target=\"_blank\">http://blog.socioboard.com/</a> &amp; <a href=\"https://twitter.com/Socioboard\" target=\"_blank\">@Socioboard</a>." +
            "</p><p style=\"color: #3F3D51; font: 15px/1.5em 'Open Sans','Helvetica Neue', arial, sans-serif; margin: 0 0 1em;\">" +
            "We are constantly sharing interesting content about Social Media, analytics and innovations on our technology. </p><p style=\"color: #3F3D51; font: 15px/1.5em 'Open Sans','Helvetica Neue', arial, sans-serif; margin: 0 0 1em;\">It will be great to have you there with us. </p>" +
            "<p style=\"color: #3F3D51; font: 15px/1.5em 'Open Sans','Helvetica Neue', arial, sans-serif; margin: 0 0 1em;\">And just as a quick reminder, if there is anything you would like to know a little more about Socioboard platform at this time please do not hesitate on getting in touch." +
            "</p><p style=\"color: #3F3D51; font: 15px/1.5em 'Open Sans','Helvetica Neue', arial, sans-serif; margin: 0 0 1em;\">Best regards, <br/><label>Socioboard </label>" +
            "</p></div></div></div> </div><!--<p><center><font size=\"2\">This email was sent by: SocioBoard., 7th Block, 80 Feet Road, Koramangala Layout, Bangalore-560095, INDIA </font></center></p>--></div></div></div></div></div></body></html>";
            html = html.Replace("[UserName]", UserName);
            string Host = "smtp.mandrillapp.com";
            int port = 587;
            string subject = "Connect to Socioboard on blog and twitter";
            string rtn = MailHelper.SendMailByMandrill(Host, port, MandrillEmail, MandrillPass, toEmail, subject, html, SenderName);
            if (rtn == "Success")
            {
                return rtn;
            }
            else
            {
                return null;
            }
        }

        public static string SendInActiveUsermail(string UserName, string toEmail, string MandrillEmail, string MandrillPass, string SenderName)
        {

            string html = "";
            string Host = "smtp.mandrillapp.com";
            int port = 587;
            string subject = "Connect to Socioboard on blog and twitter";
            string rtn = MailHelper.SendMailByMandrill(Host, port, MandrillEmail, MandrillPass, toEmail, subject, html, SenderName);
            if (rtn == "Success")
            {
                return rtn;
            }
            else
            {
                return null;
            }
        }

        public static string SendGroupRepors(string GroupName, string toEmail, SocialStat _SocialStat, FbPageStat _FacebookStats, InstagramStat _InstagramStat)
        {
            string date = DateTime.Now.AddDays(-1).ToString("MMMM dd");
            string _GroupName = GroupName;
            string email = toEmail;
            int i = 0;
            string str = "<!DOCTYPE html><html lang=\"en\"><head><title>Socioboard | Group Reports</title><meta charset=\"utf-8\"><meta name=\"viewport\" content=\"width=device-width\"><link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css\" />" +
                "<style type=\"text/css\">	#outlook a {padding: 0;}.ReadMsgBody {width: 100%;}.ExternalClass {width: 100%;}.ExternalClass,.ExternalClass p,.ExternalClass span,.ExternalClass font,.ExternalClass td,.ExternalClass div {line-height: 100%;}" +
            "body,table,td,a {-webkit-text-size-adjust: 100%;-ms-text-size-adjust: 100%;}	table,td {mso-table-lspace: 0pt;mso-table-rspace: 0pt;}		img {-ms-interpolation-mode: bicubic;}body {margin: 0;padding: 0;}img {border: 0;height: auto;line-height: 100%;outline: none;text-decoration: none;}" +
            "table {border-collapse: collapse !important;}	body {height: 100% !important;margin: 0;padding: 0;width: 100% !important;font-family: segoe UI;}.appleBody a {color: #68440a;text-decoration: none;}.appleFooter a {color: #999999;text-decoration: none;}" +
            "@media screen and (max-width: 525px) {table[class=\"wrapper\"] {width: 100% !important;}td[class=\"logo\"] {text-align: left;padding: 20px 0 20px 0 !important;}td[class=\"logo\"] img {margin: 0 auto!important;}td[class=\"mobile-hide\"] {display: none;}img[class=\"mobile-hide\"] {display: none !important;}img[class=\"img-max\"] {max-width: 100% !important;height: auto !important;}" +
            "table[class=\"responsive-table\"] {width: 100%!important;}td[class=\"padding\"] {padding: 10px 5% 15px 5% !important;}td[class=\"padding-copy\"] {padding: 10px 5% 10px 5% !important;text-align: center;}td[class=\"padding-meta\"] {padding: 30px 5% 0px 5% !important;text-align: center;}" +
            "td[class=\"no-pad\"] {padding: 0 0 20px 0 !important;}td[class=\"no-padding\"] {padding: 0 !important;}td[class=\"section-padding\"] {padding: 50px 15px 50px 15px !important;}td[class=\"section-padding-bottom-image\"] {padding: 50px 15px 0 15px !important;}td[class=\"mobile-wrapper\"] {padding: 10px 5% 15px 5% !important;}table[class=\"mobile-button-container\"] {margin: 0 auto;width: 100% !important;}" +
            "a[class=\"mobile-button\"] {width: 80% !important;padding: 15px !important;border: 0 !important;font-size: 16px !important;}}</style></head>" +
            
            "<body style=\"margin: 0; padding: 0;\"><div class=\"container\"><div class=\"row\"><div class=\"col-md-6 col-md-offset-3\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"table-layout: fixed;\"><tr><td bgcolor=\"#ffffff\">" +
            "<div align=\"center\" style=\"padding: 0px 15px 0px 15px;\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"500\" class=\"wrapper\"><tr><td style=\"padding: 20px 0px 30px 0px;\" class=\"logo\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">" +
            "<tr><td bgcolor=\"#ffffff\" width=\"200\" align=\"left\"><a href=\"http://socioboard.com\" target=\"_blank\"><img alt=\"Logo\" src=\"http://i.imgur.com/KyksxOs.png\" width=\"250\" height=\"78\" style=\"display: block; font-family: Helvetica, Arial, sans-serif; color: #666666; font-size: 16px;\" border=\"0\" /></a></td>" +
            "<td align=\"right\" style=\"padding: 0 0 5px 0; font-size: 14px; font-family: Arial, sans-serif; color: #666666; text-decoration: none; font-weight:bold;\">" +
            "<a href=\"https://www.socioboard.com/Index/Index?ReturnUrl=%2fHome\" style=\"color: #666666; text-decoration: none;\">LOGIN</a></td></tr></table></td></tr></table></td></tr></table></div></td></tr></table>" +
            "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"table-layout: fixed;\"><tr><td bgcolor=\"#ffffff\" align=\"center\" style=\"padding: 0px 15px 0px 15px;\" class=\"section-padding\">" +
            "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"500\" class=\"responsive-table\"><tr><td><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">" +
            "<tr><td><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><tbody><tr><td class=\"padding-copy\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">" +
            "<tr><td style=\"background-color:#F8680D; height:100px; text-align:center;\"><a href=\"#\" target=\"_blank\" style=\"text-align:center; color:#FFF; text-transform:uppercase; text-decoration:none; letter-spacing: 2px; font-size: 28px; font-weight: 700;\">Group Report Summary</a>" +
            "<br/><a href=\"#\" target=\"_blank\" style=\"text-align:center; color:#FFF; text-transform:uppercase; text-decoration:none; letter-spacing: 2px; font-size: 16px;\">Daily Digest</a></a></td></tr>" +
            "<tr><td><a href=\"#\" target=\"_blank\"><img src=\"http://i.imgur.com/RwgxMKl.png\" width=\"500\" height=\"100\" border=\"0\" alt=\"Can an email really be responsive?\" style=\"display: block; padding: 0; color: #666666; text-decoration: none; font-family: Helvetica, arial, sans-serif; font-size: 16px; width: 500px; height: 75px;\" class=\"img-max\">" +
            "</a></td></tr></table></td></tr></tbody></table></td></tr>" +
            
            "<tr><td><table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;font-size:16px\"><tbody>"+
            "<tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"500\" style=\"padding-left:50px;padding-right:50px;padding-top:50px;text-align:left\">" +
            "<h3 style=\"color:#808080;font-weight:700;line-height:13px;font-size:11px;letter-spacing:1px;text-transform:uppercase;margin-top:0;margin-bottom:10px;padding:0;font-family:Helvetica,Arial,sans-serif\">" +
            "<img width=\"16\" height=\"13\" style=\"padding-right:2px;font-family:Helvetica,Arial,sans-serif\" src=\"http://i.imgur.com/KPEaTAm.png\" />Your Group</h3>" +
            "<p style=\"color:#F8680D;font-weight:400;line-height:34x;font-size:26px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Helvetica,Arial,sans-serif\">" + _GroupName + "</p>" +
            "<p style=\"color:#b3b3b3;font-weight:400;line-height:18x;font-size:12px;margin-top:0;margin-bottom:10px;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Helvetica,Arial,sans-serif\">Group associated with <a target=\"_blank\" href=\"mailto:vikaskumar@globussoft.com\">"+email+"</a></p>" +
            "<hr style=\"padding-top:0;padding-bottom:0;margin-top:0;margin-bottom:0;background-color:#dddddd;border-bottom:0 solid #ffffff;border-left:0 solid #ffffff;border-right:0 solid #ffffff;border-top:0 solid #ffffff;min-height:1px\">" +
            "<p style=\"color:#808080;font-weight:700;line-height:18px;font-size:11px;letter-spacing:1px;text-transform:uppercase;margin-top:10px;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Helvetica,Arial,sans-serif\">Report Date: <span style=\"color:#4d4d4d;text-transform:none;letter-spacing:0;font-weight:400;font-size:12px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Helvetica,Arial,sans-serif\"><span><span>" + date + "</span></span>" +
            "</span></span></p><p style=\"color:#b3b3b3;font-weight:400;line-height:18x;font-size:12px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Helvetica,Arial,sans-serif\">Latest data may be missing from summary</p></td></tr></tbody></table></td></tr>" +

            "<tr><td><table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#808080;font-size:16px\">" +
            "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"500\" style=\"padding-top:50px;padding-bottom:50px;text-align:left\">" +
            "<table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#808080;font-size:16px\">" +
            "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><th width=\"360\" style=\"text-align:left;border-bottom:3px solid #2caae1\" colspan=\"2\">" +
            "<h2 style=\"margin-top:0;margin-bottom:5px;padding-top:0;padding-bottom:0;color:#4d4d4d;font-weight:400;font-size:20px;line-height:28px;font-family:Helvetica,Arial,sans-serif\">Twitter Stats</h2></th>" +
            "<th width=\"140\" style=\"text-align:right;border-bottom:3px solid #2caae1\" colspan=\"2\"> <img width=\"17\" height=\"14\" style=\"padding-right:2px;font-family:Helvetica,Arial,sans-serif\" src=\"http://i.imgur.com/hDNrQdO.png\" class=\"CToWUd\"> </th></tr>" +
            "<tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
            "<td width=\"250\" valign=\"middle\" height=\"55\" style=\"text-align:center;color:#00417b;font-weight:400;line-height:32x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:5px;padding-bottom:0;padding-left:10px;padding-right:20px;font-family:Helvetica,Arial,sans-serif\"> <img width=\"10\" height=\"25\" style=\"padding-right:2px;font-family:Helvetica,Arial,sans-serif\" src=\"http://i.imgur.com/QTwQyVL.png\" class=\"CToWUd\"> <span style=\"font-size:32px;font-weight:700\">"+ _SocialStat.male +"%</span> Male Followers </td>" +
            "<td width=\"250\" valign=\"middle\" height=\"55\" style=\"text-align:center;color:#ff9393;font-weight:400;line-height:32x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:5px;padding-bottom:0;padding-left:0;padding-right:10px;font-family:Helvetica,Arial,sans-serif\" colspan=\"3\"> <img width=\"12\" height=\"25\" style=\"padding-right:2px;font-family:Helvetica,Arial,sans-serif\" src=\"http://i.imgur.com/LvOezOQ.png\" class=\"CToWUd\"> <span style=\"font-size:32px;font-weight:700\">" + _SocialStat.female + "%</span> Female Followers </td>" +
            "</tr><tr style=\"background-color:#eeeeee\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\">"+
            "<td width=\"350\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#b3b3b3;font-weight:400;line-height:20x;font-size:11px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:253px;padding-right:10px;font-family:Helvetica,Arial,sans-serif\" colspan=\"3\">Total </td></tr>" +
            "<tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\">" +
            "@Mentions Received </td><td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\">"+ _SocialStat.Mentions +"</td>" +
            "</tr><tr style=\"background-color:#eeeeee\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
            "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\">" +
            "Direct Messages Received </td><td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\">"+ _SocialStat.Direct_Message +"</td>" +
            "</tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
            "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\">" +
            "Messages Sent </td><td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\">"+ _SocialStat.Messages_Sent +"</td>" +
            "</tr><tr style=\"background-color:#eeeeee\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
            "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\"> New Followers </td>" +
            "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\">"+ _SocialStat.New_Followers +"</td>" +
            "</tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
            "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\"> Retweets </td>" +
            "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\">"+ _SocialStat.Retweets +"</td>" +
            "</tr><tr style=\"background-color:#eeeeee\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
            "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\"> Clicks </td>" +
            "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\">" + _SocialStat.Clicks + "</td></tr>" +
            "<tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
            "<td width=\"500\" height=\"40\" style=\"text-align:right;background-color:#2caae1\" colspan=\"4\"> <a target=\"_blank\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none;padding-left:0px;padding-right:10px;padding-top:13.5px;padding-bottom:13.5px\" href=\"https://www.socioboard.com/\">View Full Twitter Report <img width=\"4\" height=\"7\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none\" src=\"http://i.imgur.com/Ec4giNS.png\" class=\"CToWUd\"></a> </td>" +
            "</tr></tbody></table></td></tr></tbody></table></td></tr>" +
            //connected twitter profiles
            "<tr><td><table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#535353;font-size:16px\">"+
            "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"400\" style=\"padding:0 0 10px;text-align:left\">" +
            "<h3 style=\"color:#808080;font-weight:400;line-height:24px;font-size:14px;text-transform:uppercase;letter-spacing:1px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Helvetica,Arial,sans-serif\">Connected Profiles </h3>" +
            "</td><td width=\"100\" style=\"padding-left:0;padding-right:50px;padding-top:0;padding-bottom:10px;text-align:right\"><br></td></tr>" +
            "<tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"500\" style=\"padding-top:0;text-align:left\" colspan=\"2\">" +
            "<table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#808080;font-size:16px\">" +
            "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"510\">";
            if (_SocialStat.lsttwitterfollower.Count > 0)
            {
                foreach (var itemtwt in _SocialStat.lsttwitterfollower)
                {
                    if (i < 4)
                    {
                        str += "<td width=\"112\" valign=\"top\" height=\"155\" style=\"padding-right:10px;text-align:center\" cellspacing=\"0\" cellpadding=\"0\">";
                        str += "<img width=\"112\" height=\"112\" style=\"font-size:11px;font-weight:700;color:#2caae1;font-family:Helvetica,Arial,sans-serif;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;margin-top:0;margin-bottom:0;margin-left:0;margin-right:0\" alt=\"" + itemtwt.Key.TwitterScreenName + "\" src=\"" + itemtwt.Key.ProfileImageUrl + "\" class=\"CToWUd\">";
                        str += "<p style=\"color:#808080;font-weight:400;line-height:14px;font-size:11px;margin-top:0;margin-bottom:0;margin-left:0;margin-right:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\"> " + itemtwt.Key.TwitterScreenName + " </p></td>";
                    }
                    i++;
                }
            }
            else { 
                str+="<tr width=\"250\"><td width=\"250\" height=\"40\" style=\"text-align:center;background-color:#2caae1\">";
                str += "<a href=\"https://www.socioboard.com/\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none;padding-left:0px;padding-right:10px;padding-top:13.5px;padding-bottom:13.5px\" target=\"_blank\">Add Twitter Account";
                str += "<img width=\"4\" height=\"7\" class=\"CToWUd\" src=\"http://i.imgur.com/Ec4giNS.png\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none\"></a> </td></tr>";
            }
            str += "</tr></tbody></table></td></tr></tbody></table></td></tr>" +
                "<tr><td><table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#535353;font-size:16px\">" +
                "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"500\" style=\"padding-top:0;text-align:left;\" colspan=\"2\">" +
                "<table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#808080;font-size:16px\">" +
                "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"510\">";
            //twitter profile followers
            i = 0;
            foreach (var itemfollower in _SocialStat.lsttwitterfollower)
            {
                str+="<td width=\"112\" valign=\"top\" height=\"155\" style=\"padding-right:10px;\" cellspacing=\"0\" cellpadding=\"0\">";
                str+="<strong style=\"width:112px;color:#808080;line-height:28px;font-size:11px;margin-top:0;margin-bottom:0;margin-left:0;margin-right:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\"> NEW FOLLOWERS </strong>";
                if (i < 4)
                {
                    foreach (var itemfollowers in itemfollower.Value)
                    {
                          str += "<p style=\"width:112px;color:#f8680d;font-weight:500;line-height:14px;font-size:11px;margin-top:0;margin-bottom:0;margin-left:0;margin-right:0;padding-top:0;padding-bottom:3%;padding-left:0;padding-right:0;font-family:Segoe UI;text-decoration: underline;\">" + itemfollowers.FromName + "</p>";
                    }
                }
                i++;
                str += "</td>";
            }
            str += "</tr></tbody></table></td></tr></tbody></table></td></tr>";
           
            //facebook
            str += "<tr><td><table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#808080;font-size:16px\">" +
                "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"500\" style=\"padding-top:50px;padding-bottom:50px;text-align:left\">" +
                "<table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#808080;font-size:16px\">" +
                "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><th width=\"360\" style=\"text-align:left;border-bottom:3px solid #3B5998\" colspan=\"2\">" +
                "<h2 style=\"margin-top:0;margin-bottom:5px;padding-top:0;padding-bottom:0;color:#4d4d4d;font-weight:400;font-size:20px;line-height:28px;font-family:Helvetica,Arial,sans-serif\">Facebook</h2>" +
                "</th><th width=\"140\" style=\"text-align:right;border-bottom:3px solid #3B5998\" colspan=\"2\"> <img width=\"17\" height=\"14\" style=\"padding-right:2px;font-family:Helvetica,Arial,sans-serif\" src=\"http://i.imgur.com/0zEBmAn.png\" class=\"CToWUd\"> </th>" +
                "</tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"55\" style=\"text-align:center;color:#00417b;font-weight:400;line-height:32x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:5px;padding-bottom:0;padding-left:10px;padding-right:20px;font-family:Helvetica,Arial,sans-serif\">&nbsp;</td>" +
                "<td width=\"250\" valign=\"middle\" height=\"55\" style=\"text-align:center;color:#ff9393;font-weight:400;line-height:32x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:5px;padding-bottom:0;padding-left:0;padding-right:10px;font-family:Helvetica,Arial,sans-serif\" colspan=\"3\">&nbsp;</td>" +
                "</tr><tr style=\"background-color:#eeeeee\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"350\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#b3b3b3;font-weight:400;line-height:20x;font-size:11px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:253px;padding-right:10px;font-family:Helvetica,Arial,sans-serif\" colspan=\"3\">" +
                "Total</td></tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\">" +
                "Total Likes</td>" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\"> "+_FacebookStats.TotalLikes+" </td>" +
                "</tr><tr style=\"background-color:#eeeeee\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\">" +
                "Talking About</td>" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\"> "+_FacebookStats.TalkingAbout+" </td>" +
                "</tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\">" +
                "New Like</td>" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\"> "+_FacebookStats.PageLike+" </td>" +
                "</tr><tr style=\"background-color:#eeeeee\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\"> Impression </td>" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\"> "+_FacebookStats.PageImpression+" </td>" +
                "</tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\"> Unlike </td>" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\"> "+_FacebookStats.PageUnlike+" </td>" +
                "</tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"500\" height=\"40\" style=\"text-align:right;background-color:#3B5998\" colspan=\"4\"> <a target=\"_blank\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none;padding-left:0px;padding-right:10px;padding-top:13.5px;padding-bottom:13.5px\" href=\"https://www.socioboard.com/\">View Full Facebook Report <img width=\"4\" height=\"7\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none\" src=\"http://i.imgur.com/Ec4giNS.png\" class=\"CToWUd\"></a> </td>" +
                "</tr></tbody></table></td></tr></tbody></table></td></tr>";

            //facebook pages
            str += "<tr><td><table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#535353;font-size:16px\"><tbody>" +
                "<tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"400\" style=\"padding:0 0 10px;text-align:left\">" +
                "<h3 style=\"color:#808080;font-weight:400;line-height:24px;font-size:14px;text-transform:uppercase;letter-spacing:1px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Helvetica,Arial,sans-serif\">Connected Pages </h3>" +
                "</td><td width=\"100\" style=\"padding-left:0;padding-right:50px;padding-top:0;padding-bottom:10px;text-align:right\">" +
                "<br></td></tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"500\" style=\"padding-top:0;text-align:left\" colspan=\"2\">" +
                "<table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#808080;font-size:16px\">" +
                "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"510\">";
            i = 0;
            if (_FacebookStats.lstFacebookpage.Count > 0)
            {
                foreach (var itempage in _FacebookStats.lstFacebookpage)
                {
                    if (i < 4)
                    {
                        str += "<td width=\"112\" valign=\"top\" height=\"155\" style=\"padding-right:10px;text-align:center\" cellspacing=\"0\" cellpadding=\"0\">";
                        str += "<img width=\"112\" height=\"112\" style=\"font-size:11px;font-weight:700;color:#2caae1;font-family:Helvetica,Arial,sans-serif;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;margin-top:0;margin-bottom:0;margin-left:0;margin-right:0\" alt=\"" + itempage.FbUserName + "\" src=\"http://graph.facebook.com/" + itempage.FbUserId + "/picture?type=small\" class=\"CToWUd\">";
                        str += "<p style=\"color:#808080;font-weight:400;line-height:14px;font-size:11px;margin-top:0;margin-bottom:0;margin-left:0;margin-right:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\"> " + itempage.FbUserName + " </p>";
                        str += "</td>";
                    }
                    i++;
                }
            }
            else { 
                str+="<tr width=\"250\"><td width=\"250\" height=\"40\" style=\"text-align:center;background-color:#3B5998\">";
                str+="<a href=\"https://www.socioboard.com\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none;padding-left:0px;padding-right:10px;padding-top:13.5px;padding-bottom:13.5px\" target=\"_blank\">Add Facebook Page";
                str+="<img width=\"4\" height=\"7\" class=\"CToWUd\" src=\"http://i.imgur.com/Ec4giNS.png\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none\"></a> </td></tr>";
            }
            str += "</tr></tbody></table></td></tr></tbody></table></td></tr>";
            //facebook account
            str += "<tr><td><table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#535353;font-size:16px\">" +
                "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"400\" style=\"padding:0 0 10px;text-align:left\">" +
                "<h3 style=\"color:#808080;font-weight:400;line-height:24px;font-size:14px;text-transform:uppercase;letter-spacing:1px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Helvetica,Arial,sans-serif\">Personal Profiles </h3>" +
                "</td><td width=\"100\" style=\"padding-left:0;padding-right:50px;padding-top:0;padding-bottom:10px;text-align:right\">" +
                "<br></td></tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"500\" style=\"padding-top:0;text-align:left\" colspan=\"2\">" +
                "<table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#808080;font-size:16px\">" +
                "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"510\">";
            i = 0;
            if (_FacebookStats.lstFacebookAccount.Count > 0)
            {
                foreach (var intemaccount in _FacebookStats.lstFacebookAccount)
                {
                    if (i < 4)
                    {
                        str += "<td width=\"112\" valign=\"top\" height=\"155\" style=\"padding-right:10px;text-align:center\" cellspacing=\"0\" cellpadding=\"0\">";
                        str += "<img width=\"112\" height=\"112\" style=\"font-size:11px;font-weight:700;color:#2caae1;font-family:Helvetica,Arial,sans-serif;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;margin-top:0;margin-bottom:0;margin-left:0;margin-right:0\" alt=\"" + intemaccount.FbUserName + "\" src=\"http://graph.facebook.com/" + intemaccount.FbUserId + "/picture?type=small\" class=\"CToWUd\">";
                        str += "<p style=\"color:#808080;font-weight:400;line-height:14px;font-size:11px;margin-top:0;margin-bottom:0;margin-left:0;margin-right:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\"> " + intemaccount.FbUserName + " </p>";
                        str += "</td>";
                    }
                    i++;
                }
            }
            else {
                str += "<tr width=\"250\"><td width=\"250\" height=\"40\" style=\"text-align:center;background-color:#3B5998\">";
                str += "<a href=\"https://www.socioboard.com\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none;padding-left:0px;padding-right:10px;padding-top:13.5px;padding-bottom:13.5px\" target=\"_blank\">Add Facebook Account";
                str += "<img width=\"4\" height=\"7\" class=\"CToWUd\" src=\"http://i.imgur.com/Ec4giNS.png\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none\"></a> </td></tr>";
            }
            str += "</tr></tbody></table></td></tr></tbody></table></td></tr>";
            //instagram

            str += "<tr><td><table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#808080;font-size:16px\"><tbody>" +
                "<tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"500\" style=\"padding-top:50px;padding-bottom:50px;text-align:left\">" +
                "<table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#808080;font-size:16px\">" +
                "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><th width=\"360\" style=\"text-align:left;border-bottom:3px solid #A97F67\" colspan=\"2\">" +
                "<h2 style=\"margin-top:0;margin-bottom:5px;padding-top:0;padding-bottom:0;color:#4d4d4d;font-weight:400;font-size:20px;line-height:28px;font-family:Helvetica,Arial,sans-serif\">Instagram</h2>" +
                "</th><th width=\"140\" style=\"text-align:right;border-bottom:3px solid #A97F67\" colspan=\"2\"> <img width=\"17\" height=\"14\" style=\"padding-right:2px;font-family:Helvetica,Arial,sans-serif\" src=\"http://goo.gl/wQGirq\" class=\"CToWUd\"> </th>" +
                "</tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"55\" style=\"text-align:center;color:#00417b;font-weight:400;line-height:32x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:5px;padding-bottom:0;padding-left:10px;padding-right:20px;font-family:Helvetica,Arial,sans-serif\">&nbsp;</td>" +
                "<td width=\"250\" valign=\"middle\" height=\"55\" style=\"text-align:center;color:#ff9393;font-weight:400;line-height:32x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:5px;padding-bottom:0;padding-left:0;padding-right:10px;font-family:Helvetica,Arial,sans-serif\" colspan=\"3\">&nbsp;</td>" +
                "</tr><tr style=\"background-color:#eeeeee\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"350\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#b3b3b3;font-weight:400;line-height:20x;font-size:11px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:253px;padding-right:10px;font-family:Helvetica,Arial,sans-serif\" colspan=\"3\">" +
                "Total</td></tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\">" +
                "New Followers</td>" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\"> "+_InstagramStat.LikesCount+" </td>" +
                "</tr><tr style=\"background-color:#eeeeee\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\">" +
                "New Followings</td>" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\"> "+_InstagramStat.NewFollowings+" </td>" +
                "</tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\">" +
                "Image Count</td>" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\"> "+_InstagramStat.ImageCount+" </td>" +
                "</tr><tr style=\"background-color:#eeeeee\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\"> Video Count </td>" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\"> "+_InstagramStat.VideoCount+" </td>" +
                "</tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\"> Likes Count </td>" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\"> "+_InstagramStat.LikesCount+" </td>" +
                "</tr><tr style=\"background-color:#eeeeee\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\"> Comment Count </td>" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\"> "+_InstagramStat.CommentCount+" </td>" +
                "</tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"500\" height=\"40\" style=\"text-align:right;background-color:#A97F67\" colspan=\"4\"> <a target=\"_blank\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none;padding-left:0px;padding-right:10px;padding-top:13.5px;padding-bottom:13.5px\" href=\"https://www.socioboard.com/\">View Full Instagram Report <img width=\"4\" height=\"7\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none\" src=\"http://i.imgur.com/Ec4giNS.png\" class=\"CToWUd\"></a> </td>" +
                "</tr></tbody></table></td></tr></tbody></table></td></tr>";
            //Instagram Account

            str += "<tr><td><table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#535353;font-size:16px\">" +
                "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"400\" style=\"padding:0 0 10px;text-align:left\">" +
                "<h3 style=\"color:#808080;font-weight:400;line-height:24px;font-size:14px;text-transform:uppercase;letter-spacing:1px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Helvetica,Arial,sans-serif\">Personal Profiles </h3>" +
                "</td><td width=\"100\" style=\"padding-left:0;padding-right:50px;padding-top:0;padding-bottom:10px;text-align:right\"><br></td></tr>" +
                "<tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"500\" style=\"padding-top:0;text-align:left\" colspan=\"2\">" +
                "<table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#808080;font-size:16px\">" +
                "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"510\">";
            if (_InstagramStat.lstInstagramAccount.Count > 0)
            {
                foreach (var iteminsta in _InstagramStat.lstInstagramAccount)
                {
                    str += "<td width=\"112\" valign=\"top\" height=\"155\" style=\"padding-right:10px;text-align:center\" cellspacing=\"0\" cellpadding=\"0\">";
                    str += "<img width=\"112\" height=\"112\" style=\"font-size:11px;font-weight:700;color:#2caae1;font-family:Helvetica,Arial,sans-serif;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;margin-top:0;margin-bottom:0;margin-left:0;margin-right:0\" alt=\"" + iteminsta.InsUserName + "\" src=\"" + iteminsta.ProfileUrl + "\" class=\"CToWUd\">";
                    str += "<p style=\"color:#808080;font-weight:400;line-height:14px;font-size:11px;margin-top:0;margin-bottom:0;margin-left:0;margin-right:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\"> "+iteminsta.InsUserName+" </p>";
                    str += "</td>";
                }
            }
            else { 
                str+="<tr width=\"250\"><td width=\"250\" height=\"40\" style=\"text-align:center;background-color:#A97F67\">"; 
                str+="<a href=\"https://www.socioboard.com\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none;padding-left:0px;padding-right:10px;padding-top:13.5px;padding-bottom:13.5px\" target=\"_blank\">Add Instagram Account";
                str+="<img width=\"4\" height=\"7\" class=\"CToWUd\" src=\"http://i.imgur.com/Ec4giNS.png\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none\"></a> </td></tr>";
            }
            str += "</tr></tbody></table></td></tr></tbody></table></td></tr>";
            //footer
            str+= "</table></td></tr></table></td></tr></table><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"table-layout: fixed;\"><tr>" +
                "<td bgcolor=\"#FA7318\" align=\"center\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\"><tr><td style=\"padding: 20px 0px 20px 0px;\">" +
                "<table width=\"500\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" class=\"responsive-table\"><tr><td align=\"center\" valign=\"middle\" style=\"font-size: 12px; line-height: 18px; font-family: Helvetica, Arial, sans-serif; color:#FFF;\">" +
                "<span class=\"appleFooter\" style=\"color:#FFF;\">Copyright &copy; 2015 <a href=\"#\" style=\"color:#000;\">Socioboard</a>. All rights reserved.</span>" +
                "<br><a href=\"#\" class=\"original-only\" style=\"color: #FFF;\">Unsubscribe</a><span class=\"original-only\" style=\"font-family: Arial, sans-serif; font-size: 12px; color: #CCC;\">&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;</span><a style=\"color: #FFF; text-decoration: none;\">If you do not want to recieve emails from us, you can unsubscribe.</a>" +
                "</td></tr></table></td></tr></table></td></tr></table></div></div></div></body></html>";

            string subject = _GroupName+"'s Social Medial Activity Summary for "+date;
            string userid = "mailer@socioboardmails.com";
            string password = "RD^&*()vikl;hhop";
            //string fromEmail = "sumit@socioboard.com";


            //string ret = MailHelper.SendMailBySendGrid(str, subject, userid, password, "Sumit Ghosh", fromEmail, "support@socioboard.com");
            //string ret = MailHelper.SendMailByMandrill("", 0, "sumit@socioboard.com", "0apEyztJdCzofdx5N7P_5Q", email, subject, str, "Sumit Ghosh");
            string ret = MailHelper.SendMailBySmtp(str, subject, userid, password, "cs101128@gmail.com");
            return ret;
        }

        public static string SendGroupReporsByDay(string GroupName, string toEmail, SocialStat _SocialStat, FbPageStat _FacebookStats, InstagramStat _InstagramStat, int days)
        {
            string date = DateTime.Now.AddDays(-days).ToString("MMMM dd") + " to " + DateTime.Now.ToString("MMMM dd");
            string _GroupName = GroupName;
            string email = toEmail;
            int i = 0;
            string str = "<!DOCTYPE html><html lang=\"en\"><head><title>Socioboard | Group Reports</title><meta charset=\"utf-8\"><meta name=\"viewport\" content=\"width=device-width\"><link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css\" />" +
                "<style type=\"text/css\">	#outlook a {padding: 0;}.ReadMsgBody {width: 100%;}.ExternalClass {width: 100%;}.ExternalClass,.ExternalClass p,.ExternalClass span,.ExternalClass font,.ExternalClass td,.ExternalClass div {line-height: 100%;}" +
            "body,table,td,a {-webkit-text-size-adjust: 100%;-ms-text-size-adjust: 100%;}	table,td {mso-table-lspace: 0pt;mso-table-rspace: 0pt;}		img {-ms-interpolation-mode: bicubic;}body {margin: 0;padding: 0;}img {border: 0;height: auto;line-height: 100%;outline: none;text-decoration: none;}" +
            "table {border-collapse: collapse !important;}	body {height: 100% !important;margin: 0;padding: 0;width: 100% !important;font-family: segoe UI;}.appleBody a {color: #68440a;text-decoration: none;}.appleFooter a {color: #999999;text-decoration: none;}" +
            "@media screen and (max-width: 525px) {table[class=\"wrapper\"] {width: 100% !important;}td[class=\"logo\"] {text-align: left;padding: 20px 0 20px 0 !important;}td[class=\"logo\"] img {margin: 0 auto!important;}td[class=\"mobile-hide\"] {display: none;}img[class=\"mobile-hide\"] {display: none !important;}img[class=\"img-max\"] {max-width: 100% !important;height: auto !important;}" +
            "table[class=\"responsive-table\"] {width: 100%!important;}td[class=\"padding\"] {padding: 10px 5% 15px 5% !important;}td[class=\"padding-copy\"] {padding: 10px 5% 10px 5% !important;text-align: center;}td[class=\"padding-meta\"] {padding: 30px 5% 0px 5% !important;text-align: center;}" +
            "td[class=\"no-pad\"] {padding: 0 0 20px 0 !important;}td[class=\"no-padding\"] {padding: 0 !important;}td[class=\"section-padding\"] {padding: 50px 15px 50px 15px !important;}td[class=\"section-padding-bottom-image\"] {padding: 50px 15px 0 15px !important;}td[class=\"mobile-wrapper\"] {padding: 10px 5% 15px 5% !important;}table[class=\"mobile-button-container\"] {margin: 0 auto;width: 100% !important;}" +
            "a[class=\"mobile-button\"] {width: 80% !important;padding: 15px !important;border: 0 !important;font-size: 16px !important;}}</style></head>" +

            "<body style=\"margin: 0; padding: 0;\"><div class=\"container\"><div class=\"row\"><div class=\"col-md-6 col-md-offset-3\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"table-layout: fixed;\"><tr><td bgcolor=\"#ffffff\">" +
            "<div align=\"center\" style=\"padding: 0px 15px 0px 15px;\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"500\" class=\"wrapper\"><tr><td style=\"padding: 20px 0px 30px 0px;\" class=\"logo\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">" +
            "<tr><td bgcolor=\"#ffffff\" width=\"200\" align=\"left\"><a href=\"http://socioboard.com\" target=\"_blank\"><img alt=\"Logo\" src=\"http://i.imgur.com/KyksxOs.png\" width=\"250\" height=\"78\" style=\"display: block; font-family: Helvetica, Arial, sans-serif; color: #666666; font-size: 16px;\" border=\"0\" /></a></td>" +
            "<td align=\"right\" style=\"padding: 0 0 5px 0; font-size: 14px; font-family: Arial, sans-serif; color: #666666; text-decoration: none; font-weight:bold;\">" +
            "<a href=\"https://www.socioboard.com/Index/Index?ReturnUrl=%2fHome\" style=\"color: #666666; text-decoration: none;\">LOGIN</a></td></tr></table></td></tr></table></td></tr></table></div></td></tr></table>" +
            "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"table-layout: fixed;\"><tr><td bgcolor=\"#ffffff\" align=\"center\" style=\"padding: 0px 15px 0px 15px;\" class=\"section-padding\">" +
            "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"500\" class=\"responsive-table\"><tr><td><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">" +
            "<tr><td><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><tbody><tr><td class=\"padding-copy\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">" +
            "<tr><td style=\"background-color:#F8680D; height:100px; text-align:center;\"><a href=\"#\" target=\"_blank\" style=\"text-align:center; color:#FFF; text-transform:uppercase; text-decoration:none; letter-spacing: 2px; font-size: 28px; font-weight: 700;\">Group Report Summary</a>" +
            "<br/><a href=\"#\" target=\"_blank\" style=\"text-align:center; color:#FFF; text-transform:uppercase; text-decoration:none; letter-spacing: 2px; font-size: 16px;\">"+days.ToString()+" - Days Digest</a></a></td></tr>" +
            "<tr><td><a href=\"#\" target=\"_blank\"><img src=\"http://i.imgur.com/RwgxMKl.png\" width=\"500\" height=\"100\" border=\"0\" alt=\"Can an email really be responsive?\" style=\"display: block; padding: 0; color: #666666; text-decoration: none; font-family: Helvetica, arial, sans-serif; font-size: 16px; width: 500px; height: 75px;\" class=\"img-max\">" +
            "</a></td></tr></table></td></tr></tbody></table></td></tr>" +

            "<tr><td><table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;font-size:16px\"><tbody>" +
            "<tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"500\" style=\"padding-left:50px;padding-right:50px;padding-top:50px;text-align:left\">" +
            "<h3 style=\"color:#808080;font-weight:700;line-height:13px;font-size:11px;letter-spacing:1px;text-transform:uppercase;margin-top:0;margin-bottom:10px;padding:0;font-family:Helvetica,Arial,sans-serif\">" +
            "<img width=\"16\" height=\"13\" style=\"padding-right:2px;font-family:Helvetica,Arial,sans-serif\" src=\"http://i.imgur.com/KPEaTAm.png\" />Your Group</h3>" +
            "<p style=\"color:#F8680D;font-weight:400;line-height:34x;font-size:26px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Helvetica,Arial,sans-serif\">" + _GroupName + "</p>" +
            "<p style=\"color:#b3b3b3;font-weight:400;line-height:18x;font-size:12px;margin-top:0;margin-bottom:10px;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Helvetica,Arial,sans-serif\">Group associated with <a target=\"_blank\" href=\"mailto:vikaskumar@globussoft.com\">" + email + "</a></p>" +
            "<hr style=\"padding-top:0;padding-bottom:0;margin-top:0;margin-bottom:0;background-color:#dddddd;border-bottom:0 solid #ffffff;border-left:0 solid #ffffff;border-right:0 solid #ffffff;border-top:0 solid #ffffff;min-height:1px\">" +
            "<p style=\"color:#808080;font-weight:700;line-height:18px;font-size:11px;letter-spacing:1px;text-transform:uppercase;margin-top:10px;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Helvetica,Arial,sans-serif\">Report Date Range: <span style=\"color:#4d4d4d;text-transform:none;letter-spacing:0;font-weight:400;font-size:12px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Helvetica,Arial,sans-serif\"><span><span>" + date + "</span></span>" +
            "</span></span></p><p style=\"color:#b3b3b3;font-weight:400;line-height:18x;font-size:12px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Helvetica,Arial,sans-serif\">Latest data may be missing from summary</p></td></tr></tbody></table></td></tr>" +

            "<tr><td><table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#808080;font-size:16px\">" +
            "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"500\" style=\"padding-top:50px;padding-bottom:50px;text-align:left\">" +
            "<table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#808080;font-size:16px\">" +
            "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><th width=\"360\" style=\"text-align:left;border-bottom:3px solid #2caae1\" colspan=\"2\">" +
            "<h2 style=\"margin-top:0;margin-bottom:5px;padding-top:0;padding-bottom:0;color:#4d4d4d;font-weight:400;font-size:20px;line-height:28px;font-family:Helvetica,Arial,sans-serif\">Twitter Stats</h2></th>" +
            "<th width=\"140\" style=\"text-align:right;border-bottom:3px solid #2caae1\" colspan=\"2\"> <img width=\"17\" height=\"14\" style=\"padding-right:2px;font-family:Helvetica,Arial,sans-serif\" src=\"http://i.imgur.com/hDNrQdO.png\" class=\"CToWUd\"> </th></tr>" +
            "<tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
            "<td width=\"250\" valign=\"middle\" height=\"55\" style=\"text-align:center;color:#00417b;font-weight:400;line-height:32x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:5px;padding-bottom:0;padding-left:10px;padding-right:20px;font-family:Helvetica,Arial,sans-serif\"> <img width=\"10\" height=\"25\" style=\"padding-right:2px;font-family:Helvetica,Arial,sans-serif\" src=\"http://i.imgur.com/QTwQyVL.png\" class=\"CToWUd\"> <span style=\"font-size:32px;font-weight:700\">" + _SocialStat.male + "%</span> Male Followers </td>" +
            "<td width=\"250\" valign=\"middle\" height=\"55\" style=\"text-align:center;color:#ff9393;font-weight:400;line-height:32x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:5px;padding-bottom:0;padding-left:0;padding-right:10px;font-family:Helvetica,Arial,sans-serif\" colspan=\"3\"> <img width=\"12\" height=\"25\" style=\"padding-right:2px;font-family:Helvetica,Arial,sans-serif\" src=\"http://i.imgur.com/LvOezOQ.png\" class=\"CToWUd\"> <span style=\"font-size:32px;font-weight:700\">" + _SocialStat.female + "%</span> Female Followers </td>" +
            "</tr><tr style=\"background-color:#eeeeee\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
            "<td width=\"350\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#b3b3b3;font-weight:400;line-height:20x;font-size:11px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:253px;padding-right:10px;font-family:Helvetica,Arial,sans-serif\" colspan=\"3\">Total </td></tr>" +
            "<tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\">" +
            "@Mentions Received </td><td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\">" + _SocialStat.Mentions + "</td>" +
            "</tr><tr style=\"background-color:#eeeeee\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
            "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\">" +
            "Direct Messages Received </td><td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\">" + _SocialStat.Direct_Message + "</td>" +
            "</tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
            "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\">" +
            "Messages Sent </td><td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\">" + _SocialStat.Messages_Sent + "</td>" +
            "</tr><tr style=\"background-color:#eeeeee\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
            "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\"> New Followers </td>" +
            "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\">" + _SocialStat.New_Followers + "</td>" +
            "</tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
            "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\"> Retweets </td>" +
            "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\">" + _SocialStat.Retweets + "</td>" +
            "</tr><tr style=\"background-color:#eeeeee\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
            "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\"> Clicks </td>" +
            "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\">" + _SocialStat.Clicks + "</td></tr>" +
            "<tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
            "<td width=\"500\" height=\"40\" style=\"text-align:right;background-color:#2caae1\" colspan=\"4\"> <a target=\"_blank\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none;padding-left:0px;padding-right:10px;padding-top:13.5px;padding-bottom:13.5px\" href=\"https://www.socioboard.com/\">View Full Twitter Report <img width=\"4\" height=\"7\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none\" src=\"http://i.imgur.com/Ec4giNS.png\" class=\"CToWUd\"></a> </td>" +
            "</tr></tbody></table></td></tr></tbody></table></td></tr>" +
                //connected twitter profiles
            "<tr><td><table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#535353;font-size:16px\">" +
            "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"400\" style=\"padding:0 0 10px;text-align:left\">" +
            "<h3 style=\"color:#808080;font-weight:400;line-height:24px;font-size:14px;text-transform:uppercase;letter-spacing:1px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Helvetica,Arial,sans-serif\">Connected Profiles </h3>" +
            "</td><td width=\"100\" style=\"padding-left:0;padding-right:50px;padding-top:0;padding-bottom:10px;text-align:right\"><br></td></tr>" +
            "<tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"500\" style=\"padding-top:0;text-align:left\" colspan=\"2\">" +
            "<table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#808080;font-size:16px\">" +
            "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"510\">";
            if (_SocialStat.lsttwitterfollower.Count > 0)
            {
                foreach (var itemtwt in _SocialStat.lsttwitterfollower)
                {
                    if (i < 4)
                    {
                        str += "<td width=\"112\" valign=\"top\" height=\"155\" style=\"padding-right:10px;text-align:center\" cellspacing=\"0\" cellpadding=\"0\">";
                        str += "<img width=\"112\" height=\"112\" style=\"font-size:11px;font-weight:700;color:#2caae1;font-family:Helvetica,Arial,sans-serif;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;margin-top:0;margin-bottom:0;margin-left:0;margin-right:0\" alt=\"" + itemtwt.Key.TwitterScreenName + "\" src=\"" + itemtwt.Key.ProfileImageUrl + "\" class=\"CToWUd\">";
                        str += "<p style=\"color:#808080;font-weight:400;line-height:14px;font-size:11px;margin-top:0;margin-bottom:0;margin-left:0;margin-right:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\"> " + itemtwt.Key.TwitterScreenName + " </p></td>";
                    }
                    i++;
                }
            }
            else
            {
                str += "<tr width=\"250\"><td width=\"250\" height=\"40\" style=\"text-align:center;background-color:#2caae1\">";
                str += "<a href=\"https://www.socioboard.com/\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none;padding-left:0px;padding-right:10px;padding-top:13.5px;padding-bottom:13.5px\" target=\"_blank\">Add Twitter Account";
                str += "<img width=\"4\" height=\"7\" class=\"CToWUd\" src=\"http://i.imgur.com/Ec4giNS.png\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none\"></a> </td></tr>";
            }
            str += "</tr></tbody></table></td></tr></tbody></table></td></tr>" +
                "<tr><td><table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#535353;font-size:16px\">" +
                "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"500\" style=\"padding-top:0;text-align:left;\" colspan=\"2\">" +
                "<table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#808080;font-size:16px\">" +
                "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"510\">";
            //twitter profile followers
            i = 0;
            foreach (var itemfollower in _SocialStat.lsttwitterfollower)
            {
                str += "<td width=\"112\" valign=\"top\" height=\"155\" style=\"padding-right:10px;\" cellspacing=\"0\" cellpadding=\"0\">";
                str += "<strong style=\"width:112px;color:#808080;line-height:28px;font-size:11px;margin-top:0;margin-bottom:0;margin-left:0;margin-right:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\"> NEW FOLLOWERS </strong>";
                if (i < 4)
                {
                    foreach (var itemfollowers in itemfollower.Value)
                    {
                        str += "<p style=\"width:112px;color:#f8680d;font-weight:500;line-height:14px;font-size:11px;margin-top:0;margin-bottom:0;margin-left:0;margin-right:0;padding-top:0;padding-bottom:3%;padding-left:0;padding-right:0;font-family:Segoe UI;text-decoration: underline;\">" + itemfollowers.FromName + "</p>";
                    }
                }
                i++;
                str += "</td>";
            }
            str += "</tr></tbody></table></td></tr></tbody></table></td></tr>";

            //facebook
            str += "<tr><td><table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#808080;font-size:16px\">" +
                "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"500\" style=\"padding-top:50px;padding-bottom:50px;text-align:left\">" +
                "<table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#808080;font-size:16px\">" +
                "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><th width=\"360\" style=\"text-align:left;border-bottom:3px solid #3B5998\" colspan=\"2\">" +
                "<h2 style=\"margin-top:0;margin-bottom:5px;padding-top:0;padding-bottom:0;color:#4d4d4d;font-weight:400;font-size:20px;line-height:28px;font-family:Helvetica,Arial,sans-serif\">Facebook</h2>" +
                "</th><th width=\"140\" style=\"text-align:right;border-bottom:3px solid #3B5998\" colspan=\"2\"> <img width=\"17\" height=\"14\" style=\"padding-right:2px;font-family:Helvetica,Arial,sans-serif\" src=\"http://i.imgur.com/0zEBmAn.png\" class=\"CToWUd\"> </th>" +
                "</tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"55\" style=\"text-align:center;color:#00417b;font-weight:400;line-height:32x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:5px;padding-bottom:0;padding-left:10px;padding-right:20px;font-family:Helvetica,Arial,sans-serif\">&nbsp;</td>" +
                "<td width=\"250\" valign=\"middle\" height=\"55\" style=\"text-align:center;color:#ff9393;font-weight:400;line-height:32x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:5px;padding-bottom:0;padding-left:0;padding-right:10px;font-family:Helvetica,Arial,sans-serif\" colspan=\"3\">&nbsp;</td>" +
                "</tr><tr style=\"background-color:#eeeeee\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"350\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#b3b3b3;font-weight:400;line-height:20x;font-size:11px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:253px;padding-right:10px;font-family:Helvetica,Arial,sans-serif\" colspan=\"3\">" +
                "Total</td></tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\">" +
                "Total Likes</td>" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\"> " + _FacebookStats.TotalLikes + " </td>" +
                "</tr><tr style=\"background-color:#eeeeee\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\">" +
                "Talking About</td>" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\"> " + _FacebookStats.TalkingAbout + " </td>" +
                "</tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\">" +
                "New Like</td>" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\"> " + _FacebookStats.PageLike + " </td>" +
                "</tr><tr style=\"background-color:#eeeeee\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\"> Impression </td>" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\"> " + _FacebookStats.PageImpression + " </td>" +
                "</tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\"> Unlike </td>" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\"> " + _FacebookStats.PageUnlike + " </td>" +
                "</tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"500\" height=\"40\" style=\"text-align:right;background-color:#3B5998\" colspan=\"4\"> <a target=\"_blank\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none;padding-left:0px;padding-right:10px;padding-top:13.5px;padding-bottom:13.5px\" href=\"https://www.socioboard.com/\">View Full Facebook Report <img width=\"4\" height=\"7\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none\" src=\"http://i.imgur.com/Ec4giNS.png\" class=\"CToWUd\"></a> </td>" +
                "</tr></tbody></table></td></tr></tbody></table></td></tr>";

            //facebook pages
            str += "<tr><td><table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#535353;font-size:16px\"><tbody>" +
                "<tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"400\" style=\"padding:0 0 10px;text-align:left\">" +
                "<h3 style=\"color:#808080;font-weight:400;line-height:24px;font-size:14px;text-transform:uppercase;letter-spacing:1px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Helvetica,Arial,sans-serif\">Connected Pages </h3>" +
                "</td><td width=\"100\" style=\"padding-left:0;padding-right:50px;padding-top:0;padding-bottom:10px;text-align:right\">" +
                "<br></td></tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"500\" style=\"padding-top:0;text-align:left\" colspan=\"2\">" +
                "<table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#808080;font-size:16px\">" +
                "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"510\">";
            i = 0;
            if (_FacebookStats.lstFacebookpage.Count > 0)
            {
                foreach (var itempage in _FacebookStats.lstFacebookpage)
                {
                    if (i < 4)
                    {
                        str += "<td width=\"112\" valign=\"top\" height=\"155\" style=\"padding-right:10px;text-align:center\" cellspacing=\"0\" cellpadding=\"0\">";
                        str += "<img width=\"112\" height=\"112\" style=\"font-size:11px;font-weight:700;color:#2caae1;font-family:Helvetica,Arial,sans-serif;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;margin-top:0;margin-bottom:0;margin-left:0;margin-right:0\" alt=\"" + itempage.FbUserName + "\" src=\"http://graph.facebook.com/" + itempage.FbUserId + "/picture?type=small\" class=\"CToWUd\">";
                        str += "<p style=\"color:#808080;font-weight:400;line-height:14px;font-size:11px;margin-top:0;margin-bottom:0;margin-left:0;margin-right:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\"> " + itempage.FbUserName + " </p>";
                        str += "</td>";
                    }
                    i++;
                }
            }
            else
            {
                str += "<tr width=\"250\"><td width=\"250\" height=\"40\" style=\"text-align:center;background-color:#3B5998\">";
                str += "<a href=\"https://www.socioboard.com\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none;padding-left:0px;padding-right:10px;padding-top:13.5px;padding-bottom:13.5px\" target=\"_blank\">Add Facebook Page";
                str += "<img width=\"4\" height=\"7\" class=\"CToWUd\" src=\"http://i.imgur.com/Ec4giNS.png\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none\"></a> </td></tr>";
            }
            str += "</tr></tbody></table></td></tr></tbody></table></td></tr>";
            //facebook account
            str += "<tr><td><table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#535353;font-size:16px\">" +
                "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"400\" style=\"padding:0 0 10px;text-align:left\">" +
                "<h3 style=\"color:#808080;font-weight:400;line-height:24px;font-size:14px;text-transform:uppercase;letter-spacing:1px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Helvetica,Arial,sans-serif\">Personal Profiles </h3>" +
                "</td><td width=\"100\" style=\"padding-left:0;padding-right:50px;padding-top:0;padding-bottom:10px;text-align:right\">" +
                "<br></td></tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"500\" style=\"padding-top:0;text-align:left\" colspan=\"2\">" +
                "<table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#808080;font-size:16px\">" +
                "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"510\">";
            i = 0;
            if (_FacebookStats.lstFacebookAccount.Count > 0)
            {
                foreach (var intemaccount in _FacebookStats.lstFacebookAccount)
                {
                    if (i < 4)
                    {
                        str += "<td width=\"112\" valign=\"top\" height=\"155\" style=\"padding-right:10px;text-align:center\" cellspacing=\"0\" cellpadding=\"0\">";
                        str += "<img width=\"112\" height=\"112\" style=\"font-size:11px;font-weight:700;color:#2caae1;font-family:Helvetica,Arial,sans-serif;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;margin-top:0;margin-bottom:0;margin-left:0;margin-right:0\" alt=\"RamkumaR\" src=\"http://graph.facebook.com/" + intemaccount.FbUserId + "/picture?type=small\" class=\"CToWUd\">";
                        str += "<p style=\"color:#808080;font-weight:400;line-height:14px;font-size:11px;margin-top:0;margin-bottom:0;margin-left:0;margin-right:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\"> " + intemaccount.FbUserName + " </p>";
                        str += "</td>";
                    }
                    i++;
                }
            }
            else
            {
                str += "<tr width=\"250\"><td width=\"250\" height=\"40\" style=\"text-align:center;background-color:#3B5998\">";
                str += "<a href=\"https://www.socioboard.com\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none;padding-left:0px;padding-right:10px;padding-top:13.5px;padding-bottom:13.5px\" target=\"_blank\">Add Facebook Account";
                str += "<img width=\"4\" height=\"7\" class=\"CToWUd\" src=\"http://i.imgur.com/Ec4giNS.png\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none\"></a> </td></tr>";
            }
            str += "</tr></tbody></table></td></tr></tbody></table></td></tr>";
            //instagram

            str += "<tr><td><table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#808080;font-size:16px\"><tbody>" +
                "<tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"500\" style=\"padding-top:50px;padding-bottom:50px;text-align:left\">" +
                "<table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#808080;font-size:16px\">" +
                "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><th width=\"360\" style=\"text-align:left;border-bottom:3px solid #A97F67\" colspan=\"2\">" +
                "<h2 style=\"margin-top:0;margin-bottom:5px;padding-top:0;padding-bottom:0;color:#4d4d4d;font-weight:400;font-size:20px;line-height:28px;font-family:Helvetica,Arial,sans-serif\">Instagram</h2>" +
                "</th><th width=\"140\" style=\"text-align:right;border-bottom:3px solid #A97F67\" colspan=\"2\"> <img width=\"17\" height=\"14\" style=\"padding-right:2px;font-family:Helvetica,Arial,sans-serif\" src=\"http://goo.gl/wQGirq\" class=\"CToWUd\"> </th>" +
                "</tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"55\" style=\"text-align:center;color:#00417b;font-weight:400;line-height:32x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:5px;padding-bottom:0;padding-left:10px;padding-right:20px;font-family:Helvetica,Arial,sans-serif\">&nbsp;</td>" +
                "<td width=\"250\" valign=\"middle\" height=\"55\" style=\"text-align:center;color:#ff9393;font-weight:400;line-height:32x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:5px;padding-bottom:0;padding-left:0;padding-right:10px;font-family:Helvetica,Arial,sans-serif\" colspan=\"3\">&nbsp;</td>" +
                "</tr><tr style=\"background-color:#eeeeee\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"350\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#b3b3b3;font-weight:400;line-height:20x;font-size:11px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:253px;padding-right:10px;font-family:Helvetica,Arial,sans-serif\" colspan=\"3\">" +
                "Total</td></tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\">" +
                "New Followers</td>" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\"> " + _InstagramStat.LikesCount + " </td>" +
                "</tr><tr style=\"background-color:#eeeeee\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\">" +
                "New Followings</td>" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\"> " + _InstagramStat.NewFollowings + " </td>" +
                "</tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\">" +
                "Image Count</td>" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\"> " + _InstagramStat.ImageCount + " </td>" +
                "</tr><tr style=\"background-color:#eeeeee\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\"> Video Count </td>" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\"> " + _InstagramStat.VideoCount + " </td>" +
                "</tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\"> Likes Count </td>" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\"> " + _InstagramStat.LikesCount + " </td>" +
                "</tr><tr style=\"background-color:#eeeeee\" cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:left;color:#4d4d4d;font-weight:400;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:10px;padding-right:0;font-family:Segoe UI;\"> Comment Count </td>" +
                "<td width=\"250\" valign=\"middle\" height=\"40\" style=\"text-align:center;color:#4d4d4d;font-weight:700;line-height:20x;font-size:14px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\" colspan=\"2\"> " + _InstagramStat.CommentCount + " </td>" +
                "</tr><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\">" +
                "<td width=\"500\" height=\"40\" style=\"text-align:right;background-color:#A97F67\" colspan=\"4\"> <a target=\"_blank\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none;padding-left:0px;padding-right:10px;padding-top:13.5px;padding-bottom:13.5px\" href=\"https://www.socioboard.com/\">View Full Instagram Report <img width=\"4\" height=\"7\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none\" src=\"http://i.imgur.com/Ec4giNS.png\" class=\"CToWUd\"></a> </td>" +
                "</tr></tbody></table></td></tr></tbody></table></td></tr>";
            //Instagram Account

            str += "<tr><td><table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#535353;font-size:16px\">" +
                "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"400\" style=\"padding:0 0 10px;text-align:left\">" +
                "<h3 style=\"color:#808080;font-weight:400;line-height:24px;font-size:14px;text-transform:uppercase;letter-spacing:1px;margin-top:0;margin-bottom:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Helvetica,Arial,sans-serif\">Personal Profiles </h3>" +
                "</td><td width=\"100\" style=\"padding-left:0;padding-right:50px;padding-top:0;padding-bottom:10px;text-align:right\"><br></td></tr>" +
                "<tr cellspacing=\"0\" cellpadding=\"0\" width=\"500\"><td width=\"500\" style=\"padding-top:0;text-align:left\" colspan=\"2\">" +
                "<table width=\"500\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"background-color:#ffffff;line-height:1.6em;color:#808080;font-size:16px\">" +
                "<tbody><tr cellspacing=\"0\" cellpadding=\"0\" width=\"510\">";
            if (_InstagramStat.lstInstagramAccount.Count > 0)
            {
                foreach (var iteminsta in _InstagramStat.lstInstagramAccount)
                {
                    str += "<td width=\"112\" valign=\"top\" height=\"155\" style=\"padding-right:10px;text-align:center\" cellspacing=\"0\" cellpadding=\"0\">";
                    str += "<img width=\"112\" height=\"112\" style=\"font-size:11px;font-weight:700;color:#2caae1;font-family:Helvetica,Arial,sans-serif;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;margin-top:0;margin-bottom:0;margin-left:0;margin-right:0\" alt=\"" + iteminsta.InsUserName + "\" src=\"" + iteminsta.ProfileUrl + "\" class=\"CToWUd\">";
                    str += "<p style=\"color:#808080;font-weight:400;line-height:14px;font-size:11px;margin-top:0;margin-bottom:0;margin-left:0;margin-right:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;font-family:Segoe UI;\"> " + iteminsta.InsUserName + " </p>";
                    str += "</td>";
                }
            }
            else
            {
                str += "<tr width=\"250\"><td width=\"250\" height=\"40\" style=\"text-align:center;background-color:#A97F67\">";
                str += "<a href=\"https://www.socioboard.com\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none;padding-left:0px;padding-right:10px;padding-top:13.5px;padding-bottom:13.5px\" target=\"_blank\">Add Instagram Account";
                str += "<img width=\"4\" height=\"7\" class=\"CToWUd\" src=\"http://i.imgur.com/Ec4giNS.png\" style=\"font-family:Segoe UI;color:#ffffff;line-height:13px;font-weight:700;font-size:12px;letter-spacing:1.5px;text-transform:uppercase;text-decoration:none\"></a> </td></tr>";
            }
            str += "</tr></tbody></table></td></tr></tbody></table></td></tr>";
            //footer
            str += "</table></td></tr></table></td></tr></table><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"table-layout: fixed;\"><tr>" +
                "<td bgcolor=\"#FA7318\" align=\"center\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\"><tr><td style=\"padding: 20px 0px 20px 0px;\">" +
                "<table width=\"500\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" class=\"responsive-table\"><tr><td align=\"center\" valign=\"middle\" style=\"font-size: 12px; line-height: 18px; font-family: Helvetica, Arial, sans-serif; color:#FFF;\">" +
                "<span class=\"appleFooter\" style=\"color:#FFF;\">Copyright &copy; 2015 <a href=\"#\" style=\"color:#000;\">Socioboard</a>. All rights reserved.</span>" +
                "<br><a href=\"#\" class=\"original-only\" style=\"color: #FFF;\">Unsubscribe</a><span class=\"original-only\" style=\"font-family: Arial, sans-serif; font-size: 12px; color: #CCC;\">&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;</span><a style=\"color: #FFF; text-decoration: none;\">If you do not want to recieve emails from us, you can unsubscribe.</a>" +
                "</td></tr></table></td></tr></table></td></tr></table></div></div></div></body></html>";

            string subject = _GroupName + "'s Social Medial Activity Summary for " + date;
            string userid = "mailer@socioboardmails.com";
            string password = "RD^&*()vikl;hhop";
            //string fromEmail = "sumit@socioboard.com";


            //string ret = MailHelper.SendMailBySendGrid(str, subject, userid, password, "Sumit Ghosh", fromEmail, "support@socioboard.com");
            //string ret = MailHelper.SendMailByMandrill("", 0, "sumit@socioboard.com", "0apEyztJdCzofdx5N7P_5Q", email, subject, str, "Sumit Ghosh");
            string ret = MailHelper.SendMailBySmtp(str, subject, userid, password, "cs101128@gmail.com");
            return ret;
        }

    }
}
